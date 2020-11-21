using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Office.API.DTOs;
using Office.Core.Services;

namespace Office.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET :> Calling the controller will give following
        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            // Entites should not be return Data Transfer Objects should be returned
            var categories = await _categoryService.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return Ok(result);
        }

       
    }
}
