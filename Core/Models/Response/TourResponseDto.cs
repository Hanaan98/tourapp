using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Response
{
    public class TourResponseDto
    {
        public Guid Id { get; set; }
        public Guid PlaceId { get; set; }
        public DateTime StartDate { get; set; }

        public int TotalSeats { get; set; }
        public int RemainingSeats { get; set; }
    }
}
