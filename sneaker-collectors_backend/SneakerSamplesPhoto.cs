using System;
using System.Collections.Generic;

namespace sneaker_collectors_backend;

public partial class SneakerSamplesPhoto
{
    public string Id { get; set; } = null!;

    public string SneakerSampleId { get; set; } = null!;

    public string PhotoSrc { get; set; } = null!;

    public virtual SneakerSample SneakerSample { get; set; } = null!;
}
