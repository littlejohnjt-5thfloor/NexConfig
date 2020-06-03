using NexConfig.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexConfig.Interfaces
{
    public interface IProductViewModelService
    {
        Task<IList<ProductViewModel>> GetProducts();

        Task<bool> SaveOrUpdateProduct(
            IList<ProductViewModel> products);
    }
}
