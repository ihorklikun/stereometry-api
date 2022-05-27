using Microsoft.EntityFrameworkCore;
using Shapes3D.BLL.Repository.Interfaces;
using Shapes3D.DAL.Context;
using Shapes3D.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.Repository
{
    public class AdminRepository : EntityRepository<Admin>, IAdminRepository
    {
        private readonly StereometryContext _dbContext;
        public AdminRepository(StereometryContext domainDbContext) : base(domainDbContext)
        {
            _dbContext = domainDbContext;
        }

        public async Task<Admin> GetByIdLink(Guid id)
        {
            return await _DbContext.Admins.FirstOrDefaultAsync(x => x.IdLink == id);
        }
    }
}
