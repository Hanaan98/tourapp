using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DbModels
{
    public class ReviewDbDto
    {
        public Guid Id { get; set; }
        public float Rating { get; set; }
        public string Comment { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Guid PlaceId { get; set; }
        public Guid UserId { get; set; }
        public PlaceDbDto Place { get; set; }
        public UserDbDto User { get; set; }
    }
}
