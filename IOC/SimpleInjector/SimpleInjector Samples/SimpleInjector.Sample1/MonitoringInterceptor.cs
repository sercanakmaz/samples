using Newtonsoft.Json;
using SimpleInjector.Sample1.Business;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector.Sample1
{
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
                        AsyncHelpers.RunSync(() => invocation.ProceedAsync());

                        var task = invocation.ReturnValue as Task;
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
