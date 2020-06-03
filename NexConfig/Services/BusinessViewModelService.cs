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
    public class BusinessViewModelService : IBusinessViewModelService
    {
        INexudusService _nexudusService { get; set; }
        IAsyncRepository<Business> _businessRepository { get; set; }

        public BusinessViewModelService(INexudusService nexudusService,
            IAsyncRepository<Business> businessRepository)
        {
            _nexudusService = nexudusService;
            _businessRepository = businessRepository;
        }

        public async Task<IList<BusinessViewModel>> GetBusinesses()
        {
            var businesses
                = (from nexudusBusiness in await _nexudusService.GetItems<Business>()
                  join savedBusiness in await _businessRepository.GetAllAsync()
                  on nexudusBusiness.Id equals savedBusiness.Id into _savedBusinessLeftJoin
                  from _savedBusniess in _savedBusinessLeftJoin.DefaultIfEmpty()
                  select new BusinessViewModel
                  {
                      Id = nexudusBusiness.Id,
                      Name = nexudusBusiness.Name,
                      Address = nexudusBusiness.Address,
                      WebAddress = nexudusBusiness.WebAddress,
                      ContactEmail = nexudusBusiness.ContactEmail,
                      IsCurrentlySaved = _savedBusniess != null,
                      // Default the item to not be saved
                      IsToBeSaved = false,
                      DateSaved = _savedBusniess != null ? _savedBusniess.DateSaved : null
                  }).ToList();

            return businesses;
        }

        public async Task<bool> SaveOrUpdateBusiness(IList<BusinessViewModel> businesses)
        {
            if (businesses == null) return true;

            // Get all businesses
            var nexudusBusinesses
                = await _nexudusService.GetItems<Business>();

            foreach (var business in businesses)
            {
                if (business.IsToBeSaved == true)
                {
                    var nexudusBusiness
                        = nexudusBusinesses.FirstOrDefault(b => b.Id == business.Id);

                    if (nexudusBusiness == null)
                    {
                        /// TODO: Log the error
                        continue;
                    }

                    if (business.DateSaved.HasValue == false)
                    {
                        // It is a new business, add it to persistent storage
                        await _businessRepository.AddAsync(nexudusBusiness);

                        /// TODO: Log the error
                    }
                    else
                    {
                        // We're updating the business
                        var itemToSave
                            = (await _businessRepository
                            .GetAsync(new FindBusinessByIdCriteria(nexudusBusiness.Id)))
                            .FirstOrDefault();

                        itemToSave.AboutUs = nexudusBusiness.AboutUs;
                        itemToSave.Address = nexudusBusiness.Address;
                        itemToSave.ContactEmail = nexudusBusiness.ContactEmail;
                        itemToSave.ContactPhoneNumber = nexudusBusiness.ContactPhoneNumber;
                        itemToSave.CookiePolicyUrl = nexudusBusiness.CookiePolicyUrl;
                        itemToSave.CountryId = nexudusBusiness.CountryId;
                        itemToSave.CurrencyId = nexudusBusiness.CurrencyId;
                        itemToSave.DefaultLanguage = nexudusBusiness.DefaultLanguage;
                        itemToSave.DefaultPaymentGatewayId = nexudusBusiness.DefaultPaymentGatewayId;
                        itemToSave.EmailContact = nexudusBusiness.EmailContact;
                        itemToSave.Fax = nexudusBusiness.Fax;
                        itemToSave.FloorSpace = nexudusBusiness.FloorSpace;
                        itemToSave.FloorSpaceUnit = nexudusBusiness.FloorSpaceUnit;
                        itemToSave.FridayClosed = nexudusBusiness.FridayClosed;
                        itemToSave.FridayCloseTime = nexudusBusiness.FridayCloseTime;
                        itemToSave.FridayOpenTime = nexudusBusiness.FridayOpenTime;
                        itemToSave.Id = nexudusBusiness.Id;
                        itemToSave.Last4Digits = nexudusBusiness.Last4Digits;
                        itemToSave.Latitude = nexudusBusiness.Latitude;
                        itemToSave.Longitude = nexudusBusiness.Longitude;
                        itemToSave.MondayClosed = nexudusBusiness.MondayClosed;
                        itemToSave.MondayCloseTime = nexudusBusiness.MondayCloseTime;
                        itemToSave.MondayOpenTime = nexudusBusiness.MondayOpenTime;
                        itemToSave.Name = nexudusBusiness.Name;
                        itemToSave.Neighborhood = nexudusBusiness.Neighborhood;
                        itemToSave.NumberOfFloors = nexudusBusiness.NumberOfFloors;
                        itemToSave.PassportBlogPostAccess = nexudusBusiness.PassportBlogPostAccess;
                        itemToSave.PassportChannels = nexudusBusiness.PassportChannels;
                        itemToSave.PassportCommunityAccess = nexudusBusiness.PassportCommunityAccess;
                        itemToSave.PassportDescription = nexudusBusiness.PassportDescription;
                        itemToSave.PassportEventAccess = nexudusBusiness.PassportEventAccess;
                        itemToSave.PassportMembersAccess = nexudusBusiness.PassportMembersAccess;
                        itemToSave.PassportPublished = nexudusBusiness.PassportPublished;
                        itemToSave.PassportSpaceName = nexudusBusiness.PassportSpaceName;
                        itemToSave.PassportTagLine = nexudusBusiness.PassportTagLine;
                        itemToSave.Phone = nexudusBusiness.Phone;
                        itemToSave.PostalCode = nexudusBusiness.PostalCode;
                        itemToSave.PreAuthLastError = nexudusBusiness.PreAuthLastError;
                        itemToSave.PrivacyPolicyUrl = nexudusBusiness.PrivacyPolicyUrl;
                        itemToSave.Quote = nexudusBusiness.Quote;
                        itemToSave.SameOpeningTimes = nexudusBusiness.SameOpeningTimes;
                        itemToSave.SaturdayClosed = nexudusBusiness.SaturdayClosed;
                        itemToSave.SaturdayCloseTime = nexudusBusiness.SaturdayCloseTime;
                        itemToSave.SaturdayOpenTime = nexudusBusiness.SaturdayOpenTime;
                        itemToSave.ShortIntroduction = nexudusBusiness.ShortIntroduction;
                        itemToSave.SimpleTimeZoneId = nexudusBusiness.SimpleTimeZoneId;
                        itemToSave.SpaceWebsiteLanguageId = nexudusBusiness.SpaceWebsiteLanguageId;
                        itemToSave.StreetName = nexudusBusiness.StreetName;
                        itemToSave.StreetNumber = nexudusBusiness.StreetNumber;
                        itemToSave.SundayClosed = nexudusBusiness.SundayClosed;
                        itemToSave.SundayCloseTime = nexudusBusiness.SundayCloseTime;
                        itemToSave.SundayOpenTime = nexudusBusiness.SundayOpenTime;
                        itemToSave.Tags = nexudusBusiness.Tags;
                        itemToSave.TermsAndConditions = nexudusBusiness.TermsAndConditions;
                        itemToSave.ThursdayClosed = nexudusBusiness.ThursdayClosed;
                        itemToSave.ThursdayCloseTime = nexudusBusiness.ThursdayCloseTime;
                        itemToSave.ThursdayOpenTime = nexudusBusiness.ThursdayOpenTime;
                        itemToSave.TownCity = nexudusBusiness.TownCity;
                        itemToSave.TuesdayClosed = nexudusBusiness.TuesdayClosed;
                        itemToSave.TuesdayCloseTime = nexudusBusiness.TuesdayCloseTime;
                        itemToSave.TuesdayOpenTime = nexudusBusiness.TuesdayOpenTime;
                        itemToSave.VenueType = nexudusBusiness.VenueType;
                        itemToSave.WebAddress = nexudusBusiness.WebAddress;
                        itemToSave.WebContact = nexudusBusiness.WebContact;
                        itemToSave.WednesdayClosed = nexudusBusiness.WednesdayClosed;
                        itemToSave.WednesdayCloseTime = nexudusBusiness.WednesdayCloseTime;
                        itemToSave.WednesdayOpenTime = nexudusBusiness.WednesdayOpenTime;

                        await _businessRepository.UpdateAsync(itemToSave);

                        /// TODO: Log the error
                    }
                }
            }

            return true;
        }
    }
}
