using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiLayerProject.API.DTOs;
using MultiLayerProject.API.Filters;
using MultiLayerProject.Core.Models;
using MultiLayerProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiLayerProject.API.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = _mapper.Map<IEnumerable<ProductDTO>>(await _productService.GetAllAsync());

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = _mapper.Map<ProductDTO>(await _productService.GetByIdAsync(id));

            return Ok(product);
        }

        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithProductsById(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);

            return Ok(_mapper.Map<ProductWithCategoryDTO>(product));
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO productDTO)
        {
            var newProduct = _mapper.Map<ProductDTO>(await _productService.AddAsync(_mapper.Map<Product>(productDTO)));

            return Created(String.Empty, newProduct);
        }

        [HttpPut]
        public IActionResult Update(ProductDTO productDTO)
        {
            var product = _productService.Update(_mapper.Map<Product>(productDTO));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;
            _productService.Remove(product);

            return NoContent();
        }
    }
}
