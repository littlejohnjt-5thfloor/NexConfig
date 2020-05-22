using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Resource : BaseEntity
    {
        public int BusinessId { get; set; }
        public string Name { get; set; }
        public int ResourceTypeId { get; set; }
        public string Description { get; set; }
        public string EmailConfirmationContent { get; set; }
        public bool Visible { get; set; }
        public bool RequiresConfirmation { get; set; }
        public int DisplayOrder { get; set; }
        public string GroupName { get; set; }
        public bool? Projector { get; set; }
        public bool? Internet { get; set; }
        public bool? ConferencePhone { get; set; }
        public bool? StandardPhone { get; set; }
        public bool? WhiteBoard { get; set; }
        public bool? LargeDisplay { get; set; }
        public bool? Catering { get; set; }
        public bool? TeaAndCoffee { get; set; }
        public bool? Drinks { get; set; }
        public bool? SecurityLocks { get; set; }
        public bool? CCTV { get; set; }
        public bool? VoiceRecorder { get; set; }
        public bool? AirConditioning { get; set; }
        public bool? Heating { get; set; }
        public bool? NaturalLight { get; set; }
        public bool? AllowMultipleBookings { get; set; }
        public int? Allocation { get; set; }
        public int? BookInAdvanceLimit { get; set; }
        public int? LateBookingLimit { get; set; }
        public int? LateCancellationLimit { get; set; }
        public int? IntervalLimit { get; set; }
        public int? NoReturnPolicy { get; set; }
        public int? NoReturnPoilcyAllResources { get; set; }
        public int? NoReturnPolicyAllUsers { get; set; }
        public int? MaxBookingLength { get; set; }
        public int? MinBookingLength { get; set; }
        public string Shifts { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public bool? HideInCalenday { get; set; }
        public bool? Archived { get; set; }
    }
}
