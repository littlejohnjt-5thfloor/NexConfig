using ApplicationCore.Criteria;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.CodeAnalysis.CSharp;
using NexConfig.Interfaces;
using NexConfig.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexConfig.Services
{
    public class ResourceTypeViewModelService : IResourceTypeViewModelService
    {
        INexudusService _nexudusService { get; set; }
        IAsyncRepository<ResourceType> _resourceTypeRepository { get; set; }

        public ResourceTypeViewModelService(INexudusService nexudusService,
            IAsyncRepository<ResourceType> resourceTypeRepository)
        {
            _nexudusService = nexudusService;
            _resourceTypeRepository = resourceTypeRepository;
        }

        public async Task<IList<ResourceTypeViewModel>> GetResourceTypes()
        {
            var temp = await _resourceTypeRepository.GetAllAsync();

            var resourceTypes
                = (from nexudusResourceType in await _nexudusService.GetItems<ResourceType>()
                   join savedResourceType in await _resourceTypeRepository.GetAllAsync()
                   on nexudusResourceType.Id equals savedResourceType.Id into _savedResourceTypeLeftJoin
                   from _savedResourceType in _savedResourceTypeLeftJoin.DefaultIfEmpty()
                   select new ResourceTypeViewModel
                   {
                       Id = nexudusResourceType.Id,
                       BusinessId = nexudusResourceType.BusinessId,
                       Name = nexudusResourceType.Name,
                       IsCurrentlySaved = _savedResourceType != null,
                       IsToBeSaved = false,
                       DateSaved = _savedResourceType != null ? _savedResourceType.DateSaved : null
                   }).ToList();

            return resourceTypes;
        }

        public async Task<bool> SaveOrUpdateResourceType(IList<ResourceTypeViewModel> resourceTypes)
        {
            if (resourceTypes == null) return true;

            var nexudusResourceTypes
                = await _nexudusService.GetItems<ResourceType>();

            foreach (var resourceType in resourceTypes)
            {
                if (resourceType.IsToBeSaved == true)
                {
                    var nexudusResourceType
                        = nexudusResourceTypes
                        .FirstOrDefault(rt => rt.Id == resourceType.Id);

                    if (nexudusResourceType == null)
                    {
                        /// TODO: Log the error

                        continue;
                    }

                    if (resourceType.DateSaved.HasValue == false)
                    {
                        // It is a new resource type, add it to persistent storage
                        await _resourceTypeRepository.AddAsync(nexudusResourceType);
                    }
                    else
                    {
                        // We're updating an existing resource type
                        var itemToSave
                            = (await _resourceTypeRepository.GetAsync(
                                new FindResourceTypeByIdCriteria(nexudusResourceType.Id)))
                                .FirstOrDefault();

                        itemToSave.BusinessId = nexudusResourceType.BusinessId;
                        itemToSave.Id = nexudusResourceType.Id;
                        itemToSave.Name = nexudusResourceType.Name;

                        await _resourceTypeRepository.UpdateAsync(itemToSave);

                        /// TODO: Log the error
                    }
                }
            }

            return true;
        }
    }
}
