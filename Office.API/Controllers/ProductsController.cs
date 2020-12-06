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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // GET :> Calling the controller will give following
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Entites should not be return Data Transfer Objects should be returned
            var products = await _productService.GetAllAsync();
            var result = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(result);
        }

        //GET :> /api/products/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsyn(id);
            var result = _mapper.Map<ProductDto>(product);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var categoryToSave = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            // null => URL of the newly added category
            return Created(string.Empty, _mapper.Map<ProductDto>(categoryToSave));
        }
    }
}