using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjector.Sample1.Business
{
    [System.AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class HandleErrorAttribute : Attribute
    {
        public LogLevel Level { get; set; }
        public HandleErrorAttribute()
        {

        }
        public HandleErrorAttribute(LogLevel level)
        {
            this.Level = level;
        }
    }
  
}
