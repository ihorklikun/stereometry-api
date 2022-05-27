using Shapes3D.BLL.Repository;
using Shapes3D.BLL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.UnitOfWork
{
    public interface IAuthentificationUnitOfWork : IUnitOfWorkBase
    {
        IRegularUserRepository RegularUserRepository { get; }
        IAdminRepository AdminRepository { get; }
    }
}
