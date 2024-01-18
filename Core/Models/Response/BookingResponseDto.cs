using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Response
{
    public class BookingResponseDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid TourId { get; set; }
        public int Seats { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string CNIC { get; set; } = "";
        public Boolean Cancelled { get; set; } = false;
        public Boolean Paid { get; set; } = false;

        public TourResponseDto Tour { get; set; }
       
        
    }
}
