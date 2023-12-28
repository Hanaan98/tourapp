using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DbModels
{
    public class PlaceDbDto
    {
        public Guid Id { get; set; }
        public string Location { get; set; } = "";
        public string Description { get; set; } = "";
        public string Image { get; set; } = "";
        public string Details { get; set; } = "";
        public double Price { get; set; }
        public string Departure { get; set; } = "";
        public int Days { get; set; }
        public IList<TourDbDto> Tours { get; set; } = new List<TourDbDto>();
        public IList<ReviewDbDto> Reviews { get; set; } = new List<ReviewDbDto>();
    }
}
