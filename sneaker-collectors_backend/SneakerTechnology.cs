using System;
using System.Collections.Generic;

namespace sneaker_collectors_backend;

public partial class SneakerTechnology
{
    public string Id { get; set; } = null!;

    public string Technology { get; set; } = null!;

    public virtual ICollection<SneakerSample> SneakerSamples { get; set; } = new List<SneakerSample>();
}
