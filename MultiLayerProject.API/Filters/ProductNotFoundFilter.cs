using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MultiLayerProject.API.DTOs;
using MultiLayerProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiLayerProject.API.Filters
{
    public class ProductNotFoundFilter:ActionFilterAttribute
    {
        private readonly IProductService _productService;
        public ProductNotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var product = await _productService.GetByIdAsync(id);

            if(product != null)
            {
                await next();
            }
            else
            {
                ErrorDTO errorDTO = new ErrorDTO();
                errorDTO.Status = 404;
                errorDTO.Errors.Add($"{id} ID'li ürün veritabanında bulunamadı.");
                context.Result = new NotFoundObjectResult(errorDTO);
            }
        }
    }
}
