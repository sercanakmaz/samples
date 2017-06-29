using SimpleInjector.Sample1.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleInjector.Sample1.Business.Operations
{
    public class FlightOperation : IFlightOperation
    {
        public  BusinessResultBase<FlightResponse> Search(FlightRequest request)
        {
            Thread.Sleep(1500);
            throw new NotImplementedException();
            return new BusinessResultBase<FlightResponse>
            {
                IsSucceed = true,
                Data = new FlightResponse
                {
                    Items = new List<FlightItem>
                    {
                        new FlightItem { FlightNumber = "01" },
                        new FlightItem { FlightNumber = "02" },
                        new FlightItem { FlightNumber = "03" },
                    }
                }
            };
        }
    }

    public interface IFlightOperation : IBusinessOperation
    {
        BusinessResultBase<FlightResponse> Search(FlightRequest request);
    }
}
