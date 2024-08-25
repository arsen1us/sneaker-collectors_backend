namespace sneaker_collectors_backend.Models.Database
{
    public class SneakerColor
    {
        public string Id { get; set; } = null!;
        public string Color { get; set; } = null!;

        public virtual SneakerSample SneakerSample { get; set; }
    }
}
