using Shapes3D.BLL.Models.ShapeType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.Services.Interface
{
    public interface IShapeTypeService
    {
        public Task<IEnumerable<GetShapeTypeViewModel>> GetAll();
        public Task Create(string name);
    }
}
