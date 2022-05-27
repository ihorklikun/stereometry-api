using Shapes3D.BLL.Repository;
using Shapes3D.BLL.Repository.Interfaces;
using Shapes3D.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.UnitOfWork
{
    public class AuthentificationUnitOfWork : IAuthentificationUnitOfWork
    {
        private StereometryContext _DbContext;
        private IAdminRepository _adminRepository;
        private IRegularUserRepository _regularUserRepository;

        public AuthentificationUnitOfWork(StereometryContext DbContext)
        {
            _DbContext = DbContext;
        }

        public IAdminRepository AdminRepository => _adminRepository ??= new AdminRepository(_DbContext);
        public IRegularUserRepository RegularUserRepository => _regularUserRepository ??= new RegularUserRepository(_DbContext);

        public async Task<int> Save() => await _DbContext.SaveChangesAsync();
    }
}
