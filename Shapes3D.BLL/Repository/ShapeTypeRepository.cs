using Microsoft.EntityFrameworkCore;
using Shapes3D.BLL.Repository.Interfaces;
using Shapes3D.DAL.Context;
using Shapes3D.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.Repository
{
    public class ShapeTypeRepository : EntityRepository<ShapeType>, IShapeTypeRepository
    {
        public ShapeTypeRepository(StereometryContext domainDbContext) : base(domainDbContext)
        {
        }

        public async Task<ShapeType> GetByShapeName(string shapeType)
        {
            return await _DbContext.ShapeTypes.FirstOrDefaultAsync(x => x.Name == shapeType);
        }
    }
}
