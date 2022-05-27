using AutoMapper;
using Shapes3D.BLL.Models.ShapeType;
using Shapes3D.BLL.Services.Interface;
using Shapes3D.BLL.UnitOfWork;
using Shapes3D.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.Services
{
    public class ShapeTypeService : IShapeTypeService
    {
        private readonly IShapeUnitOfWork _shapeUnitOfWork;
        private readonly IMapper _mapper;

        public ShapeTypeService(IShapeUnitOfWork shapeUnitOfWork, IMapper mapper)
        {
            _shapeUnitOfWork = shapeUnitOfWork;
            _mapper = mapper;
        }

        public async Task Create(string name)
        {
            var existed_shapeType = await _shapeUnitOfWork.ShapeTypeRepository.GetByShapeName(name);

            if (existed_shapeType != null)
            {
                throw new Exception("This shape type is exist");
            }
            else
            {
                var new_category = new ShapeType()
                {
                    Name = name
                };

                await _shapeUnitOfWork.ShapeTypeRepository.Add(new_category);
            }

            await _shapeUnitOfWork.Save();
        }

        public async Task<IEnumerable<GetShapeTypeViewModel>> GetAll()
        {
            var shapes = await _shapeUnitOfWork.ShapeTypeRepository.GetAll();

            var shapesViewModel = _mapper.Map<IEnumerable<ShapeType>, IEnumerable<GetShapeTypeViewModel>>(shapes);

            return shapesViewModel;
        }
    }
}
