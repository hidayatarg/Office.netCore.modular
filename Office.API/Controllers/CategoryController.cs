using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Office.API.DTOs;
using Office.Core.Models;
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
        public async Task<IActionResult> GetAll()
        {
            // Entites should not be return Data Transfer Objects should be returned
            var categories = await _categoryService.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Ok(result);
        }

        //GET :> /api/Category/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsyn(id);
            var result = _mapper.Map<CategoryDto>(category);
            return Ok(result);
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProductsById(int id)
        {
            var category = await _categoryService.GetWithProductsByIdAsync(id);
            return Ok(_mapper.Map<CategoryWithProductDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var categoryToSave = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            // null => URL of the newly added category
            return Created(string.Empty, _mapper.Map<CategoryDto>(categoryToSave));
        }

        // not asynchronus method
        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {
            var categoryToUpdate = _categoryService.Update(_mapper.Map<Category>(categoryDto));
            // donot return anything return 204
            // problem for big query if you return
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var categoryToRemove = _categoryService.GetByIdAsyn(id).Result;
            _categoryService.Remove(categoryToRemove);

            return NoContent();
        }

    }
}
