using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MultiLayerProject.Core.Repositories;

namespace MultiLayerProject.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }

        Task CommitAsync();
        void Commit();

    }
}
