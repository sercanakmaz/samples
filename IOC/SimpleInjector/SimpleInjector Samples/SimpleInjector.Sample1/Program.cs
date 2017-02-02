using Newtonsoft.Json;
using SimpleInjector.Sample1.Business;
using SimpleInjector.Sample1.Business.Operations;
using SimpleInjector.Sample1.Entity.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

            var operation = container.GetInstance<IFlightOperation>();

            var result = operation.Search(new FlightRequest
            {
                Origin = "A",
                Destination = "B"
            });

            if (result.IsSucceed)
            {
                foreach (var item in result.Data.Items)
                {
                    Console.WriteLine(item.FlightNumber);
                }
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
            var method = invocation.GetConcreteMethod() as MethodInfo;
            var parametersAsDictionary = GetMethodParameters(invocation, method);
            var handleErrorAttribute = GetHandleErrorAttribute(method);

            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                var returnTypeInstance = Activator.CreateInstance(method.ReturnType) as BusinessResultBase;

                invocation.ReturnValue = returnTypeInstance;

                string title = invocation.InvocationTarget.GetType().Name + ":" + method.Name;

                Console.WriteLine(title);
                Console.WriteLine("Hata oluştu: {0}", ex.ToString());
                Console.WriteLine("LogLevel: {0}", handleErrorAttribute.Level);
                Console.WriteLine("Parametreler: {0}", JsonConvert.SerializeObject(parametersAsDictionary));
            }
        }

        private static Dictionary<string, object> GetMethodParameters(IInvocation invocation, System.Reflection.MethodInfo method)
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

        private static HandleErrorAttribute GetHandleErrorAttribute(System.Reflection.MethodInfo method)
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
