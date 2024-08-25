namespace sneaker_collectors_backend.Models.Database
{
    public class SneakerTechnology
    {
        public string Id { get; set; }
        public string SneakerId { get; set; }
        public string Technology { get; set; }

        public virtual SneakerSample SneakerSample { get; set; }
    }
}
