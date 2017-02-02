using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector.Sample1.Business
{
    public class BusinessResultBase
    {
        public bool IsSucceed { get; set; }
    }
    public class BusinessResultBase<T>: BusinessResultBase
    {
        public T Data { get; set; }
    }
}
