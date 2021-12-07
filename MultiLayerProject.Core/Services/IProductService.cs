using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MultiLayerProject.Core.Models;

namespace MultiLayerProject.Core.Services
{
    public interface IProductService:IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
