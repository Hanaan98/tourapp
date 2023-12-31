namespace Core.Models.Request
{
    [Serializable]
    public class PlaceRequestDto
    {
        public string Location { get; set; } = "";
        public string Description { get; set; } = "";
        public string Image { get; set; } = "";
        public string Details { get; set; } = "";
        public double Price { get; set; }
        public string Departure { get; set; } = "";
        public int Days { get; set; }
    }
    
}