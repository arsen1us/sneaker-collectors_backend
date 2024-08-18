using System;
using System.Collections.Generic;

namespace sneaker_collectors_backend.Models.Database;

public partial class BrandFounder
{
    public string Id { get; set; } = null!;

    public string BrandId { get; set; } = null!;

    public string History { get; set; } = null!;

    public string PhotoSrc { get; set; } = null!;

    public DateOnly? BornIn { get; set; }

    public DateOnly? DiedIn { get; set; }

    public virtual Brand Brand { get; set; } = null!;
}
