using Shapes3D.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.Repository.Interfaces
{
    public interface IAdminRepository : IEntityRepository<Admin>
    {
        public Task<Admin> GetByIdLink(Guid id);
    }
}
