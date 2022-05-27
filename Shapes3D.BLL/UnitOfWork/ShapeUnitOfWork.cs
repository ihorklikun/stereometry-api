using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes3D.BLL.Repository;
using Shapes3D.BLL.Repository.Interfaces;
using Shapes3D.DAL.Context;

namespace Shapes3D.BLL.UnitOfWork
{
    public class ShapeUnitOfWork : IShapeUnitOfWork
    {
        private StereometryContext _DbContext;
        private IShapeRepository _shapeRepository;
        private IShapeTypeRepository _shapeTypeRepository;

        public ShapeUnitOfWork(StereometryContext DbContext)
        {
            _DbContext = DbContext;
        }

        public IShapeRepository ShapeRepository => _shapeRepository ??= new ShapeRepository(_DbContext);
        public IShapeTypeRepository ShapeTypeRepository => _shapeTypeRepository ??= new ShapeTypeRepository(_DbContext);

        public async Task<int> Save() => await _DbContext.SaveChangesAsync();
    }
}
