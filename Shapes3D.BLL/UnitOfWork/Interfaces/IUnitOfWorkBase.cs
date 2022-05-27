using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.UnitOfWork
{
    public interface IUnitOfWorkBase
    {
        Task<int> Save();
    }
}
