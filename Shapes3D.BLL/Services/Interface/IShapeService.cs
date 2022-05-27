using Shapes3D.BLL.Models.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.Services.Interface
{
    public interface IShapeService
    {
        public Task<IEnumerable<GetShapeViewModel>> GetAll();
        public Task<IEnumerable<GetShapeViewModel>> GetAllForGallary();
        public Task Create(ShapeViewModel shape);
        public Task DeleteById(Guid id);
        public Task AddToGallary(Guid id);
        public Task RemoveFromGallary(Guid id);
        public Task GetByTypeId(Guid id);
        public Task GetByTypeName(string name);

    }
}
