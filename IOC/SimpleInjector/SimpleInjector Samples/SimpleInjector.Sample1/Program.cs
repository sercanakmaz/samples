using SimpleInjector.Sample1.Business;
using SimpleInjector.Sample1.Business.Operations;
using SimpleInjector.Sample1.Entity.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector.Sample1
{
    class Program
    {
        public static Container container = new Container();
        static void Main(string[] args)
        {
            RegisterIOC();

            var operation = container.GetInstance<IAccountOperation>();

            var result = operation.Login("sercanakmaz", "1234");

            if (result != null)
            {
                Console.WriteLine(result.FullName);
            }

            Console.ReadKey();
        }

        static void RegisterIOC()
        {
            container.Register<IAccountOperation, AccountOperation>(Lifestyle.Singleton);
            container.Register<IFlightOperation, FlightOperation>(Lifestyle.Singleton);
            container.RegisterSingleton<MonitoringInterceptor>();

            container.InterceptWith<MonitoringInterceptor>(f =>
            {
                var businessInterface = f.GetInterface(typeof(IBusinessOperation).Name);
                var hasBusinessInterface = businessInterface != null;

                return hasBusinessInterface;
            });

            container.Verify();
        }
    }
    public class MonitoringInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var watch = Stopwatch.StartNew();
            var method = invocation.GetConcreteMethod();
            var parametersAsDictionary = GetMethodParameters(invocation, method);
            var handleErrorAttribute = GetHandleErrorAttribute(method);

            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                invocation.ReturnValue = new LoginResult { FullName = "hata" };

                Console.WriteLine("Hata oluştu: {0}", ex.ToString());
                Console.WriteLine("LogLevel: {0}", handleErrorAttribute.Level);
                Console.WriteLine("Parametreler");
                foreach (var item in parametersAsDictionary)
                {
                    Console.WriteLine(" {0}: {1}", item.Key, item.Value);
                }
            }
        }

        private static Dictionary<string, object> GetMethodParameters(IInvocation invocation, System.Reflection.MethodBase method)
        {
            var parametersAsDictionary = new Dictionary<string, object>();
            int index = 0;
            foreach (var item in method.GetParameters())
            {
                parametersAsDictionary.Add(item.Name, invocation.Arguments[index]);
                index++;
            }

            return parametersAsDictionary;
        }

        private static HandleErrorAttribute GetHandleErrorAttribute(System.Reflection.MethodBase method)
        {
            var handleErrorAttribute = method.GetCustomAttributes(true).FirstOrDefault(p => p.GetType() == typeof(HandleErrorAttribute)) as HandleErrorAttribute;

            if (handleErrorAttribute == null)
            {
                handleErrorAttribute = new HandleErrorAttribute();
            }

            return handleErrorAttribute;
        }
    }
}
