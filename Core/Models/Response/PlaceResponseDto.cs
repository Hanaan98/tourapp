namespace Core.Models.Response
{
   
    public class PlaceResponseDto
    {
        public Guid Id { get; set; }
        public string Location { get; set; } = "";
        public string Description { get; set; } = "";
        public string Image { get; set; } = "";
        public string Details { get; set; } = "";
        public double Price { get; set; }
        public string Departure { get; set; } = "";
        public int Days { get; set; }
    }

}