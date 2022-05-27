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
    public class RegularUserRepository : EntityRepository<RegularUser>, IRegularUserRepository
    {
        public RegularUserRepository(StereometryContext domainDbContext) : base(domainDbContext)
        {
        }

        public async Task<bool> Contains(Guid id)
        {
            var o = await _DbContext.RegularUsers.FirstOrDefaultAsync(x => x.Id == id);
            if (o != null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Contains(RegularUser regularUser)
        {
            return await _DbContext.RegularUsers.ContainsAsync(regularUser);
        }

        public async Task<RegularUser> GetByIdLink(Guid id)
        {
            return await _DbContext.RegularUsers.FirstOrDefaultAsync(x => x.IdLink == id);
        }
    }
}
