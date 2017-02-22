using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using JohnsonNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Sample1
{
    [Table("dbo.[User]")]
    public class User
    {
        [ExplicitKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var connection = JohnsonManager.Config.Current.GetConnection("LocalSqlServer");
            connection.Open();

            var user = new User
            {
                Id = 3,
                Name = "Sercan",
                CreatedDate = DateTime.Now
            };

            connection.Insert(user);

            Console.ReadKey();
        }
    }
}
