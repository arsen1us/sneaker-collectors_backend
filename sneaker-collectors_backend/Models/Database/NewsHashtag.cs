using System;
using System.Collections.Generic;

namespace sneaker_collectors_backend.Models.Database;

public partial class NewsHashtag
{
    public string Id { get; set; } = null!;

    public string NewsId { get; set; } = null!;

    public string Hashtag { get; set; } = null!;

    public virtual News News { get; set; } = null!;
}
