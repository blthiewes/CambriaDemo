using Microsoft.EntityFrameworkCore;
using MySQL.Data.Entity.Extensions;

namespace Demo.Database
{
    public static class DemoContextFactory
    {
        public static DemoContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DemoContext>();
            optionsBuilder.UseMySQL(connectionString);

            //Ensure database creation
            var context = new DemoContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        }
    }
}
