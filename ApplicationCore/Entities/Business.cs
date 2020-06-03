using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Business : BaseEntity
    {
        public string Name { get; set; }
        public int DefaultLanguage { get; set; }
        public int SpaceWebsiteLanguageId { get; set; }
        public string WebAddress { get; set; }
        public int DefaultPaymentGatewayId { get; set; }
        public string TermsAndConditions { get; set; }
        public string ShortIntroduction { get; set; }
        public string AboutUs { get; set; }
        public string Quote { get; set; }
        public string PrivacyPolicyUrl { get; set; }
        public string CookiePolicyUrl { get; set; }
        public string WebContact { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string EmailContact { get; set; }
        public int CountryId { get; set; }
        public int CurrencyId { get; set; }
        public int SimpleTimeZoneId { get; set; }
        public string Last4Digits { get; set; }
        public string PreAuthLastError { get; set; }
        public string PassportChannels { get; set; }
        public bool PassportPublished { get; set; }
        public string PassportSpaceName { get; set; }
        public string PassportTagLine { get; set; }
        public int VenueType { get; set; }
        public string Tags { get; set; }
        public int? NumberOfFloors { get; set; }
        public int? FloorSpace { get; set; }
        public int FloorSpaceUnit { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public string PassportDescription { get; set; }
        public string TownCity { get; set; }
        public string PostalCode { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string Neighborhood { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public int PassportMembersAccess { get; set; }
        public int PassportEventAccess { get; set; }
        public int PassportCommunityAccess { get; set; }
        public int PassportBlogPostAccess { get; set; }
        public int? MondayOpenTime { get; set; }
        public int? MondayCloseTime { get; set; }
        public int? TuesdayOpenTime { get; set; }
        public int? TuesdayCloseTime { get; set; }
        public int? WednesdayOpenTime { get; set; }
        public int? WednesdayCloseTime { get; set; }
        public int? ThursdayOpenTime { get; set; }
        public int? ThursdayCloseTime { get; set; }
        public int? FridayOpenTime { get; set; }
        public int? FridayCloseTime { get; set; }
        public int? SaturdayOpenTime { get; set; }
        public int? SaturdayCloseTime { get; set; }
        public int? SundayOpenTime { get; set; }
        public int? SundayCloseTime { get; set; }
        public bool MondayClosed { get; set; }
        public bool TuesdayClosed { get; set; }
        public bool WednesdayClosed { get; set; }
        public bool ThursdayClosed { get; set; }
        public bool FridayClosed { get; set; }
        public bool SaturdayClosed { get; set; }
        public bool SundayClosed { get; set; }
        public bool SameOpeningTimes { get; set; }
    }
}
