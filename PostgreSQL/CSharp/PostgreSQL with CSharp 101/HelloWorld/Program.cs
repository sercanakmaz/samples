using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite.PostgreSQL;
using ServiceStack.OrmLite;
using ServiceStack.Text;
using ServiceStack.DataAnnotations;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbFactory = new OrmLiteConnectionFactory("Host=localhost;Username=postgres;Password=1;Database=test", PostgreSqlDialect.Provider);

            using (var db = dbFactory.Open())
            {

                db.DropAndCreateTable<User>(); //DROP (if exist) and CREATE Table from User POCO

                db.Insert(                     //INSERT multiple Users by params
                    new User { Id = 1, Name = "A", CreatedDate = DateTime.Now },
                    new User { Id = 2, Name = "B", CreatedDate = DateTime.Now },
                    new User { Id = 3, Name = "C", CreatedDate = DateTime.Now },
                    new User { Id = 4, Name = "C", CreatedDate = DateTime.Now });

                var rowsC = db.Select<User>(x => x.Name == "C"); //SELECT by typed expression
                "No of 'C' Rows: {0}, Ids:".Print(rowsC.Count);  //= 2
                rowsC.ConvertAll(x => x.Id).PrintDump();         //= 3,4

                db.Delete<User>(x => x.Name == "C");             //DELETE by typed expression

                var remainingC = db.Select<User>("Name= @name", new { name = "C" }); //Custom SQL
                "No of 'C' Rows: {0}".Print(remainingC.Count);   //= 0

                var rowsLeft = db.Select<User>();
                "Rows Left: {0}".Print(rowsLeft.Count);          //= 2
                rowsLeft.PrintDump();                            //= A,B
            }

            Console.ReadKey();
        }

        class User
        {
            public long Id { get; set; }

            [Index]
            public string Name { get; set; }
            public DateTime CreatedDate { get; set; }
            public override string ToString() => Name;
        }
    }
}
