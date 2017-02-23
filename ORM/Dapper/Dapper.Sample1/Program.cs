using JohnsonNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExtensions;

namespace Dapper.Sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomersRepository repository = new CustomersRepository();
            var lead = repository.GetByID("AROUT");

            Console.WriteLine(lead.CompanyName);
            Console.ReadKey();
        }
    }
}
