using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Office.Core.Services;

namespace Office.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET :> Calling the controller will give following
        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            // Entites should not be return Data Transfer Objects should be returned
            var category = await _categoryService.GetAllAsync();
            return Ok(category);
        }

       
    }
}
