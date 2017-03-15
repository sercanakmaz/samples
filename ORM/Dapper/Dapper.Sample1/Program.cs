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
            var repository = new CategoryRepository();

            var category = new Categories
            {
                CategoryName = "Müşteri"
            };

            repository.Save(category);


            Console.ReadKey();
        }
    }
}
