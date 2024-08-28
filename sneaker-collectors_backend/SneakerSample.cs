using System;
using System.Collections.Generic;

namespace sneaker_collectors_backend;

public partial class SneakerSample
{
    public string Id { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Discription { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string ColorId { get; set; } = null!;

    public string MaterialId { get; set; } = null!;

    public string PurposeId { get; set; } = null!;

    public string TechnologyId { get; set; } = null!;

    public string BrandId { get; set; } = null!;

    public virtual Brand Brand { get; set; } = null!;

    public virtual SneakerColor Color { get; set; } = null!;

    public virtual SneakerMaterial Material { get; set; } = null!;

    public virtual SneakerPurpose Purpose { get; set; } = null!;

    public virtual ICollection<SneakerSamplesPhoto> SneakerSamplesPhotos { get; set; } = new List<SneakerSamplesPhoto>();

    public virtual SneakerTechnology Technology { get; set; } = null!;
}
