using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MultiLayerProject.Core.Models;

namespace MultiLayerProject.Core.Repositories
{
    public interface IProductRepository:IRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
