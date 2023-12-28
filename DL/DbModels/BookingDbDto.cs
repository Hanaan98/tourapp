using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DbModels
{
    public class BookingDbDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid TourId { get; set; }
        public int Seats { get; set; } = 1;
        public UserDbDto User { get; set; }
        public TourDbDto Tour { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string CNIC { get; set; } = "";
        public DateTime BookedOn { get; set; } = DateTime.Now;
        public Boolean Cancelled { get; set; } = false;
        public Boolean Paid { get; set; } = false;
    }
}
