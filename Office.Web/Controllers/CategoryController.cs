using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Office.API.Filters;
using Office.Core.Models;
using Office.Core.Services;
using Office.Web.ApiService;
using Office.Web.DTOs;

namespace Office.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly CategoryApiService _categoryApiService;

        public CategoryController(ICategoryService categoryService, IMapper mapper, CategoryApiService categoryApiService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryApiService.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryApiService.AddAsync(categoryDto);
            return RedirectToAction("Index");
        }

        // Update/5
        [ServiceFilter(typeof(CategoryNotFoundFilter))]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryApiService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _categoryApiService.Update(categoryDto);
            return RedirectToAction("Index");
        }

        // Delete/5
        [ServiceFilter(typeof(CategoryNotFoundFilter))]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _categoryApiService.Remove(id);
            return RedirectToAction("Index");
        }

    }
}
