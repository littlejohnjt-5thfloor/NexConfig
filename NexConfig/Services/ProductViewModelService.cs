using ApplicationCore.Criteria;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Scaffolding;
using NexConfig.Interfaces;
using NexConfig.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NexConfig.Services
{
    public class ProductViewModelService : IProductViewModelService
    {
        INexudusService _nexudusService { get; set; }
        IAsyncRepository<Product> _productRepository { get; set; }

        public ProductViewModelService(INexudusService nexudusService,
            IAsyncRepository<Product> productRepository)
        {
            _nexudusService = nexudusService;
            _productRepository = productRepository;
        }

        public async Task<IList<ProductViewModel>> GetProducts()
        {
            var products
                = (from nexudusProduct in await _nexudusService.GetItems<Product>()
                   join savedProduct in await _productRepository.GetAllAsync()
                   on nexudusProduct.Id equals savedProduct.Id into _savedProductLeftJoin
                   from _savedProduct in _savedProductLeftJoin.DefaultIfEmpty()
                   select new ProductViewModel
                   {
                       Id = nexudusProduct.Id,
                       Name = nexudusProduct.Name,
                       Price = nexudusProduct.Price,
                       IsCurrentlySaved = _savedProduct != null,
                       IsToBeSaved = false,
                       DateSaved = _savedProduct != null ? _savedProduct.DateSaved : null
                   }).ToList();

            return products;
        }

        public async Task<bool> SaveOrUpdateProduct(IList<ProductViewModel> products)
        {
            if (products == null) return true;

            // Get all nexudus products
            var nexudusProducts
                = await _nexudusService.GetItems<Product>();

            foreach (var product in products)
            {
                if (product.IsToBeSaved == true)
                {
                    var nexudusProduct
                        = nexudusProducts.FirstOrDefault(p => p.Id == product.Id);

                    if (nexudusProduct == null)
                    {
                        /// TODO: Log the error

                        continue;
                    }

                    if (product.DateSaved.HasValue == false)
                    {
                        // It is a new pass, add it to persistent storage
                        await _productRepository.AddAsync(nexudusProduct);
                    }
                    else
                    {
                        // We're updating an existing product
                        var itemToSave
                            = (await _productRepository.GetAsync(
                               new FindProductByIdCriteria(nexudusProduct.Id)))
                               .FirstOrDefault();

                        itemToSave.AllowNegativeStock = nexudusProduct.AllowNegativeStock;
                        itemToSave.Archived = nexudusProduct.Archived;
                        itemToSave.AvailableAs = nexudusProduct.AvailableAs;
                        itemToSave.BusinessId = nexudusProduct.BusinessId;
                        itemToSave.CurrencyId = nexudusProduct.CurrencyId;
                        itemToSave.DisplayOrder = nexudusProduct.DisplayOrder;
                        itemToSave.FinancialAccountId = nexudusProduct.FinancialAccountId;
                        itemToSave.Id = nexudusProduct.Id;
                        itemToSave.Name = nexudusProduct.Name;
                        itemToSave.OnlyForContacts = nexudusProduct.OnlyForContacts;
                        itemToSave.OnlyForMembers = nexudusProduct.OnlyForMembers;
                        itemToSave.Price = nexudusProduct.Price;
                        itemToSave.Sku = nexudusProduct.Sku;
                        itemToSave.Starred = nexudusProduct.Starred;
                        itemToSave.StockAlertLevel = nexudusProduct.StockAlertLevel;
                        itemToSave.Tags = nexudusProduct.Tags;
                        itemToSave.TaxRateId = nexudusProduct.TaxRateId;
                        itemToSave.TrackStock = nexudusProduct.TrackStock;
                        itemToSave.Visible = nexudusProduct.Visible;

                        await _productRepository.UpdateAsync(itemToSave);

                        /// TODO: Log the error
                    }
                }
            }

            return true;
        }
    }
}
