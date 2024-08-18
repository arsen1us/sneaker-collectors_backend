using System;
using System.Collections.Generic;

namespace sneaker_collectors_backend.Models.Database;

public partial class NewsPhoto
{
    public string Id { get; set; } = null!;

    public string NewsId { get; set; } = null!;

    public string PhotoUrl { get; set; } = null!;

    public virtual News News { get; set; } = null!;
}
