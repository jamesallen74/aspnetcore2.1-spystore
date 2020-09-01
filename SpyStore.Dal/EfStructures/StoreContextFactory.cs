using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SpyStore.Dal.EfStructures
{
    public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
    {
        public StoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
            
            var connectionString =
                @"Server=(localdb)\MSSQLLocalDB;Database=SpyStore21;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=true";
            
            optionsBuilder
              .UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
            
            optionsBuilder
              .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            
            Console.WriteLine(connectionString);
            return new StoreContext(optionsBuilder.Options);
        }
    }
}