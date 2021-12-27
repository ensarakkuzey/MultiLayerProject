using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MultiLayerProject.Core.Services;
using MultiLayerProject.Website.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiLayerProject.Website.Filters
{
    public class CategoryNotFoundFilter:ActionFilterAttribute
    {
        private readonly ICategoryService _categoryService;

        public CategoryNotFoundFilter(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var category = await _categoryService.GetByIdAsync(id);

            if(category != null)
            {
                await next();
            }
            else
            {
                ErrorDTO errorDTO = new ErrorDTO();
                errorDTO.Errors.Add($"{id} ID'li kategori veritabanında bulunamadı.");
                context.Result = new RedirectToActionResult("Error", "Home", errorDTO);
            }
        }
    }
}
