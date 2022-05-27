using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes3D.BLL.Repository;
using Shapes3D.BLL.Repository.Interfaces;

namespace Shapes3D.BLL.UnitOfWork
{
    public interface IShapeUnitOfWork : IUnitOfWorkBase
    {
        IShapeRepository ShapeRepository { get; }
        IShapeTypeRepository ShapeTypeRepository { get; }
    }
}
