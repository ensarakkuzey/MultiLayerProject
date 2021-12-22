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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = _mapper.Map<IEnumerable<CategoryDTO>>(await _categoryService.GetAllAsync());

            return Ok(categories);
        }

        [ServiceFilter(typeof(CategoryNotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = _mapper.Map<CategoryDTO>(await _categoryService.GetByIdAsync(id));

            return Ok(category);
        }

        [ServiceFilter(typeof(CategoryNotFoundFilter))]
        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProductsById(int id)
        {
            var category = await _categoryService.GetWithProductsByIdAsync(id);

            return Ok(_mapper.Map<CategoryWithProductsDTO>(category));
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(CategoryDTO categoryDTO)
        {
            var newCategory = _mapper.Map<CategoryDTO>(await _categoryService.AddAsync(_mapper.Map<Category>(categoryDTO)));

            return Created(String.Empty, newCategory);
        }

        [HttpPut]
        public IActionResult Update(CategoryDTO categoryDTO)
        {
            var category = _categoryService.Update(_mapper.Map<Category>(categoryDTO));

            return NoContent();
        }

        [ServiceFilter(typeof(CategoryNotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(category);

            return NoContent();
        }


    }
}
