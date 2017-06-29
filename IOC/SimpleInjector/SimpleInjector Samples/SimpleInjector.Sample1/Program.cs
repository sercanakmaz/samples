using SimpleInjector.Sample1.Business;
using SimpleInjector.Sample1.Business.Operations;
using SimpleInjector.Sample1.Core;
using SimpleInjector.Sample1.Entity.Base;
using System;
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

            var result =  operation.Search(new FlightRequest
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

}
