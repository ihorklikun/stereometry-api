using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.DAL.Context
{
    public class DesignTimeStereometryDbContext : IDesignTimeDbContextFactory<StereometryContext>
    {
        public StereometryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StereometryContext>();

            optionsBuilder.UseSqlServer(@"Server=ACER-IHOR\SQLEXPRESS;Initial Catalog=StereometryDb;Integrated Security=True");
            return new StereometryContext(optionsBuilder.Options);
        }
    }
}
