using Microsoft.AspNetCore.Mvc;
using Shapes3D.API.Controllers.Base;
using Shapes3D.BLL.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes3D.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShapeTypeController : BaseController
    {
        private readonly IShapeTypeService _shapeTypeService;

        public ShapeTypeController(IShapeTypeService shapeTypeyService)
        {
            _shapeTypeService = shapeTypeyService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var categories = await _shapeTypeService.GetAll();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // POST: ExercisesController/Create
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Create(string name)
        {
            try
            {
                await _shapeTypeService.Create(name);
                return Ok("New category created!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
