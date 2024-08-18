using System;
using System.Collections.Generic;

namespace sneaker_collectors_backend.Models.Database;

public partial class SneakerMaterial
{
    public string Id { get; set; } = null!;

    public string SneakerId { get; set; } = null!;

    public string UpMaterial { get; set; } = null!;

    public string InsideMaterial { get; set; } = null!;

    public string SoleMaterial { get; set; } = null!;

    public string InsoleMaterial { get; set; } = null!;

    public virtual SneakerSample Sneaker { get; set; } = null!;
}
