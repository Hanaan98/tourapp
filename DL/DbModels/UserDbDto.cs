using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DbModels
{
    public class UserDbDto
    {
        public Guid Id { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string FirstName { get; set; } = "";
        [Column(TypeName = "VARCHAR(100)")]
        public string LastName { get; set; } = "";
        [Column(TypeName = "VARCHAR(100)")]
        public string Email { get; set; } = "";
        [MinLength(8, ErrorMessage = "Password should atleast be of 8 characters")]
        public string Password { get; set; } = "";
        public Role Role { get; set; }
        public IList<BookingDbDto> Bookings { get; set; } = new List<BookingDbDto>();
        public IList<ReviewDbDto> Reviews { get; set; } = new List<ReviewDbDto>();
    }
}
