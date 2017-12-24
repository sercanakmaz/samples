using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DotNetCore.Boilerplate.Data.Dapper.Context
{
    public class CommonContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
