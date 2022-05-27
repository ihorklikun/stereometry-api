using Shapes3D.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.Repository
{
    public interface IShapeRepository : IEntityRepository<Shape>
    {
        Task<IEnumerable<Shape>> GetByDate();
        Task<IEnumerable<Shape>> GetByDateDesc();
    }
}
