using System;
using System.Collections.Generic;

namespace sneaker_collectors_backend.Models.Database;

public partial class SneakerPurpose
{
    public string Id { get; set; } = null!;

    public string SneakerSampleId { get; set; } = null!;

    public string Purpose { get; set; } = null!;

    public virtual SneakerSample SneakerSample { get; set; } = null!;
}
