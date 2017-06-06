using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleWindsor.Sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();

            container.Install(new InterceptorInstaller());
            container.Install(new ManagerInstaller());

            var manager = container.Resolve<IExampleManager>();

            manager.ExampleMethod();

            Console.ReadKey();
        }
    }
    public interface IExampleManager
    {
        void ExampleMethod();
    }
    public class ExampleManager : IExampleManager
    {
        public void ExampleMethod()
        {
            Debug.WriteLine("Doing Work...");
        }
    }
    public class ManagerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .Where(type => type.Name.EndsWith("Manager"))
                .WithServiceDefaultInterfaces()
                .Configure(c => c.LifestyleTransient().Interceptors<ExampleInterceptor>()));
        }
    }
    public class ExampleInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Debug.WriteLine(string.Format("Before method: {0}", invocation.Method.Name));
            invocation.Proceed();
            Debug.WriteLine(string.Format("After method: {0}", invocation.Method.Name));
        }
    }
    public class InterceptorInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Component.For<ExampleInterceptor>()
                                   .LifestyleTransient());
        }
    }
}
