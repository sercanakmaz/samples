using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetBuilerplate.Sample1.Tasks
{
    public class Person : Entity
    {
        public virtual string Name { get; set; }
    }
}
