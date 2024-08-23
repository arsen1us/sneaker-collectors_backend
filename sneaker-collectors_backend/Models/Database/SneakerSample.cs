using System;
using System.Collections.Generic;
using sneaker_collectors_backend.Models.Database;

namespace sneaker_collectors_backend;

public partial class SneakerSample
{
    public string Id { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Discription { get; set; } = null!;

    public string BrandId { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public virtual ICollection<SneakerMaterial> SneakerMaterials { get; set; } = new List<SneakerMaterial>();

    public virtual ICollection<SneakerPurpose> SneakerPurposes { get; set; } = new List<SneakerPurpose>();

    public virtual ICollection<SneakerSamplesPhoto> SneakerSamplesPhotos { get; set; } = new List<SneakerSamplesPhoto>();
}
