using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiLayerProject.Core.Models;
using MultiLayerProject.Core.Services;
using MultiLayerProject.Website.DTOs;
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
    }
}
