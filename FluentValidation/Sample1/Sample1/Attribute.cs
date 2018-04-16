using System;
using System.Collections.Generic;
using System.Text;

namespace Sample1
{
    public class Attribute
    {
        public string Code { get; set; }
        public int? MinCharacter { get; set; }
        public int? MaxCharacter { get; set; }
        public bool Required { get; set; }
    }
}
