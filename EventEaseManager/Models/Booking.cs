using System;
using System.ComponentModel.DataAnnotations;

namespace EventEaseManager.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        public int VenueId { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        public Venue? Venue { get; set; }
        public Event? Event { get; set; }
        
    }
}
