using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shapes3D.DAL.Context;
using Shapes3D.DAL.Entities;

namespace Shapes3D.BLL.Repository
{
    public class ShapeRepository : EntityRepository<Shape>, IShapeRepository
    {
        public ShapeRepository(StereometryContext DbContext) : base(DbContext)
        {
        }

        public async Task<IEnumerable<Shape>> GetByDate()
        {
            return await _DbContext.Shapes.OrderBy(e => e.AddedDateTime).ToListAsync();
        }

        public async Task<IEnumerable<Shape>> GetByDateDesc()
        {
            return await _DbContext.Shapes.OrderByDescending(e => e.AddedDateTime).ToListAsync();
        }
    }
}
