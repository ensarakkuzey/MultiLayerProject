using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiLayerProject.Core.Models;
using MultiLayerProject.Core.Services;
using MultiLayerProject.Website.DTOs;
using MultiLayerProject.Website.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiLayerProject.Website.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories = _mapper.Map<IEnumerable<CategoryDTO>>(await _categoryService.GetAllAsync());

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryDTO));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var category = _mapper.Map<CategoryDTO>(await _categoryService.GetByIdAsync(id));

            return View(category);      
        }

        [HttpPost]
        public IActionResult Update(CategoryDTO categoryDTO)
        {
            _categoryService.Update(_mapper.Map<Category>(categoryDTO));

            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(CategoryNotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            _categoryService.Remove(category);

            return RedirectToAction("Index");
        }
    }
}
