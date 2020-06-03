using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface INexudusService
    {
        Task<IReadOnlyList<T>> GetItems<T>();
        Task<T> GetItem<T>(int id) where T : class;
    }
}
