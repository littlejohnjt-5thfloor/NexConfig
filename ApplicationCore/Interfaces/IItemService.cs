using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IItemService<T>
    {
        Task<IReadOnlyList<T>> GetItems();
    }
}
