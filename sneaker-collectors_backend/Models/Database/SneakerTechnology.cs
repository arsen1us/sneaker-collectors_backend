namespace sneaker_collectors_backend.Models.Database
{
    public class SneakerTechnology
    {
        public string Id { get; set; } = null!;

        public string Technology { get; set; } = null!;

        public virtual ICollection<SneakerSample> SneakerSamples { get; set; } = new List<SneakerSample>();
    }
}
