using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBContext
{
    public class DbContextFactory : IDesignTimeDbContextFactory<SqlDbContext>
    {
        public SqlDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SqlDbContext>();
            var connectionString = "Server=.;Database=NME;Trusted_Connection=True;";
            builder.UseSqlServer(connectionString);
            return new SqlDbContext(builder.Options);
        }
    }
}
