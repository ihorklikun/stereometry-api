using Microsoft.AspNetCore.Mvc;
using Shapes3D.API.Controllers.Base;
using Shapes3D.BLL.Models.Shape;
using Shapes3D.BLL.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes3D.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShapeController : BaseController
    {
        private readonly IShapeService _shapeService;

        public ShapeController(IShapeService exerciseService)
        {
            _shapeService = exerciseService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var exercises = await _shapeService.GetAll();
                return Ok(exercises);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Create(ShapeViewModel newShape)
        {
            try
            {
                await _shapeService.Create(newShape);
                return Ok("New exercise created!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
