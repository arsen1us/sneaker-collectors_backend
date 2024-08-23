namespace sneaker_collectors_backend.Models
{
    public class SneakerOverview
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public string BrandTitle { get; set; }

        public string Discription { get; set; }

        public string Color { get; set; }

        public string Purpose { get; set; }

        public string Gender { get; set; }

        public string UpMaterial { get; set; }

        public string InsideMaterial { get; set; }

        public string SoleMaterial { get; set; }

        public string IsSoleMaterial { get; set; }

        public List<string> PhotoSrc { get; set; }

        //public string Technology { get; set; }
        //public DateOnly? CreatedAt { get; set; }
    }
}
