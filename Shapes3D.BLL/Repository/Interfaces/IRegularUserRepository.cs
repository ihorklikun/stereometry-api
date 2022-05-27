using Shapes3D.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.Repository.Interfaces
{
    public interface IRegularUserRepository : IEntityRepository<RegularUser>
    {
        Task<bool> Contains(Guid id);
        Task<bool> Contains(RegularUser id);
        public Task<RegularUser> GetByIdLink(Guid id);
    }
}
