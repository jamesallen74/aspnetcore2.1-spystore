using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Diagnostics;

namespace SpyStore.Dal.EfStructures
{
    public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext> 
    { 
        public StoreContext CreateDbContext(string[] args) 
        { 
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>(); 
            
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SpyStore21;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; 
            optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure()); 
            optionsBuilder.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning)); 
            
            Debug.WriteLine(connectionString); 
            
            return new StoreContext(optionsBuilder.Options); 
        } 
    }
}
