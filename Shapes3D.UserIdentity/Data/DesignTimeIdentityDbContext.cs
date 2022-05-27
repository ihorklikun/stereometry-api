using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.UserIdentity.Data
{
    public class DesignTimeIdentityDbContext : IDesignTimeDbContextFactory<IdentityDbContext>
    {
        public IdentityDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityDbContext>();

            optionsBuilder.UseSqlServer(@"Server=ACER-IHOR\SQLEXPRESS;Initial Catalog=Stereometry_IdentityDb;Integrated Security=True");
            return new IdentityDbContext(optionsBuilder.Options);
        }
    }
}
