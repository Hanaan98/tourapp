using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DbModels
{
    public class TourDbDto
    {
        public Guid Id { get; set; }
        public Guid PlaceId { get; set; }
        public PlaceDbDto Place { get; set; }
        public DateTime StartDate { get; set; }

        public int TotalSeats { get; set; }
        public int RemainingSeats { get; set; }

        public IList<BookingDbDto> Bookings { get; set; } = new List<BookingDbDto>();
    }
}
