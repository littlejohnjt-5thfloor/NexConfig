using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ItemService<T> : IItemService<T>
    {
        private INexudusService _nexudusService { get; set; }

        public ItemService(INexudusService nexudusService)
        {
            _nexudusService = nexudusService;
        }

        public async Task<IReadOnlyList<T>> GetItems()
        {
            return await _nexudusService.GetItems<T>();
        }
    }
}
