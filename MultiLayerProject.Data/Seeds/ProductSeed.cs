using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLayerProject.Data.Seeds
{
    class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _categoryIdList;

        public ProductSeed(int[] categoryIdList)
        {
            _categoryIdList = categoryIdList;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Tükenmez Kalem", Price = 11.50m, Stock = 250, CategoryId = _categoryIdList[0] },
                new Product { Id = 2, Name = "Uçlu Kalem", Price = 9.50m, Stock = 500, CategoryId = _categoryIdList[0] },
                new Product { Id = 3, Name = "Dolma Kalem", Price = 28.45m, Stock = 115, CategoryId = _categoryIdList[0] },
                new Product { Id = 4, Name = "Kurşun Kalem", Price = 5.25m, Stock = 1000, CategoryId = _categoryIdList[0] },
                new Product { Id = 5, Name = "Çizgili Defter", Price = 18.00m, Stock = 250, CategoryId = _categoryIdList[1] },
                new Product { Id = 6, Name = "Kareli Defter", Price = 19.50m, Stock = 425, CategoryId = _categoryIdList[1] },
                new Product { Id = 7, Name = "Çizgisiz Defter", Price = 17.25m, Stock = 325, CategoryId = _categoryIdList[1] }
                );
        }
    }
}
