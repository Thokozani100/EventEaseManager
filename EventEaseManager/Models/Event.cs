using System.ComponentModel.DataAnnotations;

namespace EventEaseManager.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        public string EventName { get; set; }

        public DateTime EventDate { get; set; }

        public string? Description { get; set; }

        [Required]
        public int VenueId { get; set; }

        public Venue? Venue { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
