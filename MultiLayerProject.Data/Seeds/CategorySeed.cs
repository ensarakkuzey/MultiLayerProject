using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLayerProject.Data.Seeds
{
    class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly int[] _categoryIdList;

        public CategorySeed(int[] categoryIdList)
        {
            _categoryIdList = categoryIdList;
        }
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = _categoryIdList[0], Name = "Kalemler"},
                new Category { Id = _categoryIdList[1], Name = "Defterler" }
                );
        }
    }
}
