using Castle.Windsor;
using System;
using System.Collections.Generic;
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

            container.Register(Castle.MicroKernel.Registration.Component.For<Main>());
            container.Register(Castle.MicroKernel.Registration.Component.For<IDependency1>().ImplementedBy<Dependency1>());

            var mainThing = container.Resolve<Main>();
            mainThing.DoSomething();

            Console.ReadKey();
        }
    }
    public interface IDependency1
    {
        object SomeObject { get; set; }
    }
    public class Dependency1 : IDependency1
    {
        public object SomeObject { get; set; }
    }
    public class Main
    {
        private IDependency1 object1;

        public Main(IDependency1 dependency1)
        {
            object1 = dependency1;
        }

        public void DoSomething()
        {
            object1.SomeObject = "Hello World";
        }
    }
}
