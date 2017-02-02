using SimpleInjector.Sample1.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector.Sample1.Business.Operations
{
    public class FlightOperation : IFlightOperation
    {
        public FlightResponse Search(FlightRequest request)
        {
            return new FlightResponse
            {
                Items = new List<FlightItem>
                {
                    new FlightItem { FlightNumber = "01" },
                    new FlightItem { FlightNumber = "02" },
                    new FlightItem { FlightNumber = "03" },
                }
            };
        }
    }

    public interface IFlightOperation: IBusinessOperation
    {
        FlightResponse Search(FlightRequest request);
    }
}
