using ApplicationCore.Criteria;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using NexConfig.Interfaces;
using NexConfig.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexConfig.Services
{
    public class ResourceViewModelService : IResourceViewModelService
    {
        INexudusService _nexudusService { get; set; }
        IAsyncRepository<Resource> _resourceRepository { get; set; }

        public ResourceViewModelService(INexudusService nexudusService,
            IAsyncRepository<Resource> resourceRepository)
        {
            _nexudusService = nexudusService;
            _resourceRepository = resourceRepository;
        }

        public async Task<IList<ResourceViewModel>> GetResources()
        {
            var resources
                = (from nexudusResource in await _nexudusService.GetItems<Resource>()
                   join savedResource in await _resourceRepository.GetAllAsync()
                   on nexudusResource.Id equals savedResource.Id into _savedReourceLeftJoin
                   from _savedResource in _savedReourceLeftJoin.DefaultIfEmpty()
                   select new ResourceViewModel
                   {
                       Id = nexudusResource.Id,
                       Name = nexudusResource.Name,
                       IsCurrentlySaved = _savedResource != null,
                       IsToBeSaved = false,
                       DateSaved = _savedResource != null ? _savedResource.DateSaved : null
                   }).ToList();

            return resources;
        }

        public async Task<bool> SaveOrUpdateResource(IList<ResourceViewModel> resources)
        {
            if (resources == null) return true;

            // Get all nexudus products
            var nexudusResources
                = await _nexudusService.GetItems<Resource>();

            foreach (var resource in resources)
            {
                if (resource.IsToBeSaved == true)
                {
                    var nexudusResource
                        = nexudusResources.FirstOrDefault(r => r.Id == resource.Id);

                    if (nexudusResource == null)
                    {
                        /// TODO: Log the error

                        continue;
                    }

                    if (resource.DateSaved.HasValue == false)
                    {
                        // It is a new pass, add it to persistent storage
                        await _resourceRepository.AddAsync(nexudusResource);
                    }
                    else
                    {
                        // We're updating an existing product
                        var itemToSave
                            = (await _resourceRepository.GetAsync(
                               new FindResourceByIdCriteria(nexudusResource.Id)))
                               .FirstOrDefault();

                        itemToSave.AirConditioning = nexudusResource.AirConditioning;
                        itemToSave.Allocation = nexudusResource.Allocation;
                        itemToSave.AllowMultipleBookings = nexudusResource.AllowMultipleBookings;
                        itemToSave.Archived = nexudusResource.Archived;
                        itemToSave.BookInAdvanceLimit = nexudusResource.BookInAdvanceLimit;
                        itemToSave.BusinessId = nexudusResource.BusinessId;
                        itemToSave.Catering = nexudusResource.Catering;
                        itemToSave.CCTV = nexudusResource.CCTV;
                        itemToSave.ConferencePhone = nexudusResource.ConferencePhone;
                        itemToSave.Description = nexudusResource.Description;
                        itemToSave.DisplayOrder = nexudusResource.DisplayOrder;
                        itemToSave.Drinks = itemToSave.Drinks;
                        itemToSave.EmailConfirmationContent = nexudusResource.EmailConfirmationContent;
                        itemToSave.GroupName = nexudusResource.GroupName;
                        itemToSave.Heating = nexudusResource.Heating;
                        itemToSave.HideInCalenday = nexudusResource.HideInCalenday;
                        itemToSave.Id = nexudusResource.Id;
                        itemToSave.Internet = nexudusResource.Internet;
                        itemToSave.IntervalLimit = nexudusResource.IntervalLimit;
                        itemToSave.LargeDisplay = nexudusResource.LargeDisplay;
                        itemToSave.LateBookingLimit = nexudusResource.LateBookingLimit;
                        itemToSave.LateCancellationLimit = nexudusResource.LateCancellationLimit;
                        itemToSave.Latitude = nexudusResource.Latitude;
                        itemToSave.Longitude = nexudusResource.Longitude;
                        itemToSave.MaxBookingLength = nexudusResource.MaxBookingLength;
                        itemToSave.MinBookingLength = nexudusResource.MinBookingLength;
                        itemToSave.Name = nexudusResource.Name;
                        itemToSave.NaturalLight = nexudusResource.NaturalLight;
                        itemToSave.NoReturnPoilcyAllResources = nexudusResource.NoReturnPoilcyAllResources;
                        itemToSave.NoReturnPolicy = nexudusResource.NoReturnPolicy;
                        itemToSave.NoReturnPolicyAllUsers = nexudusResource.NoReturnPolicyAllUsers;
                        itemToSave.Projector = nexudusResource.Projector;
                        itemToSave.RequiresConfirmation = nexudusResource.RequiresConfirmation;
                        itemToSave.ResourceTypeId = nexudusResource.ResourceTypeId;
                        itemToSave.SecurityLocks = nexudusResource.SecurityLocks;
                        itemToSave.Shifts = nexudusResource.Shifts;
                        itemToSave.StandardPhone = nexudusResource.StandardPhone;
                        itemToSave.TeaAndCoffee = nexudusResource.TeaAndCoffee;
                        itemToSave.Visible = nexudusResource.Visible;
                        itemToSave.VoiceRecorder = nexudusResource.VoiceRecorder;
                        itemToSave.WhiteBoard = nexudusResource.WhiteBoard;

                        await _resourceRepository.UpdateAsync(itemToSave);

                        /// TODO: Log the error
                    }
                }
            }

            return true;
        }
    }
}
