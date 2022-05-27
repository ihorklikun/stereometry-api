using AutoMapper;
using Shapes3D.BLL.Models.Shape;
using Shapes3D.BLL.Services.Interface;
using Shapes3D.BLL.UnitOfWork;
using Shapes3D.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.Services
{
    public class ShapeService : IShapeService
    {
        private readonly IShapeUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShapeService(IShapeUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task AddToGallary(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Create(ShapeViewModel shape)
        {
            if (shape == null)
            {
                throw new ValidationException("Data don't exists");
            }

            var shapeMapped = _mapper.Map<ShapeViewModel, Shape>(shape);

        }

        public Task DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetShapeViewModel>> GetAll()
        {
            var shapes =  await _unitOfWork.ShapeRepository.GetAll();

            if (shapes == null)
                throw new ValidationException($"Can't find shapes. Operation canceled");

            return _mapper.Map<IEnumerable<Shape>, IEnumerable<GetShapeViewModel>>(shapes);
        }

        public Task<IEnumerable<GetShapeViewModel>> GetAllForGallary()
        {
            throw new NotImplementedException();
        }

        public Task GetByTypeId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task GetByTypeName(string name)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromGallary(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
