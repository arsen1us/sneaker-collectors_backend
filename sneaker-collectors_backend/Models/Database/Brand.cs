using System;
using System.Collections.Generic;

namespace sneaker_collectors_backend.Models.Database;

public partial class Brand
{
    public string Id { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string LogoSrc { get; set; } = null!;

    public string History { get; set; } = null!;

    public DateOnly CreatedAt { get; set; }

    public string OfficialSiteUrl { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<BrandFounder> BrandFounders { get; set; } = new List<BrandFounder>();

    public virtual ICollection<UserSneaker> UserSneakers { get; set; } = new List<UserSneaker>();
}
