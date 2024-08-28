using System;
using System.Collections.Generic;

namespace sneaker_collectors_backend;

public partial class SneakerMaterial
{
    public string Id { get; set; } = null!;

    public string UpMaterial { get; set; } = null!;

    public string InsideMaterial { get; set; } = null!;

    public string SoleMaterial { get; set; } = null!;

    public string InsoleMaterial { get; set; } = null!;

    public virtual ICollection<SneakerSample> SneakerSamples { get; set; } = new List<SneakerSample>();
}
