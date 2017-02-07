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
            var task = MainAsync(args);

            task.Wait();

            if (task.Exception != null)
            {
                throw task.Exception;
            }
        }
        static async Task MainAsync(string[] args)
        {
            RegisterIOC();

            var operation = container.GetInstance<IFlightOperation>();

            var result = await operation.Search(new FlightRequest
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
        private static readonly MethodInfo handleAsyncMethodInfo = typeof(MonitoringInterceptor).GetMethod("HandleAsyncWithResult", BindingFlags.Instance | BindingFlags.NonPublic);
        public void Intercept(IInvocation invocation)
        {
            var watch = Stopwatch.StartNew();
            var methodInfo = invocation.GetConcreteMethod() as MethodInfo;
            var methodDelegateType = GetMethodDelegateType(methodInfo);
            var parametersAsDictionary = GetMethodParameters(invocation, methodInfo);
            var handleErrorAttribute = GetHandleErrorAttribute(methodInfo);

            try
            {
                switch (methodDelegateType)
                {
                    case MethodType.Synchronous:
                        invocation.Proceed();
                        break;
                    case MethodType.AsyncAction:
                    case MethodType.AsyncFunction:
                        invocation.Proceed();

                        var task = (Task)invocation.ReturnValue;
                        task.Wait();

                        if (task.Exception != null)
                        {
                            throw task.Exception;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                if (invocation.ReturnValue is Task)
                {
                    // Task.FromResult metoduna generic type dinamik olarak gönderilerek defaultValue dönen bir Task oluşturulur.

                    var fromResultMethodInfo = typeof(Task).GetMethod("FromResult");
                    var genericType = methodInfo.ReturnType.GetGenericArguments()[0];
                    var genericMethod = fromResultMethodInfo.MakeGenericMethod(genericType);
                    var defaultReturnInstance = Activator.CreateInstance(genericType);

                    invocation.ReturnValue = genericMethod.Invoke(this, new[] { defaultReturnInstance });
                }
                else
                {
                    var defaultReturnInstance = Activator.CreateInstance(methodInfo.ReturnType);

                    invocation.ReturnValue = defaultReturnInstance;
                }


                string title = invocation.InvocationTarget.GetType().Name + ":" + methodInfo.Name;

                Console.WriteLine(title);
                Console.WriteLine("Hata oluştu: {0}", ex.InnerException.ToString());
                Console.WriteLine("LogLevel: {0}", handleErrorAttribute.Level);
                Console.WriteLine("Parametreler: {0}", JsonConvert.SerializeObject(parametersAsDictionary));
            }
        }

        private MethodType GetMethodDelegateType(MethodInfo methodInfo)
        {
            var returnType = methodInfo.ReturnType;
            if (returnType == typeof(Task))
                return MethodType.AsyncAction;
            if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>))
                return MethodType.AsyncFunction;
            return MethodType.Synchronous;
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
        private enum MethodType
        {
            Synchronous,
            AsyncAction,
            AsyncFunction
        }
    }
}
