namespace sneaker_collectors_backend.Models
{
    public class SneakerOverviewLite
    {
        public string Id { get; set; }
        public string Model {  get; set; }
        public string Title { get; set; }
        public string BrandLogo { get; set; }
        public string BrandTitle { get; set;}
        public string Color { get; set; }
        public string Purpose { get; set; }
        public List<string> PhotoSrc { get; set; }
    }
}
