using System;
using System.Collections.Generic;

namespace sneaker_collectors_backend.Models.Database;

public partial class UserSneakersPhoto
{
    public string Id { get; set; } = null!;

    public string UserSneakerId { get; set; } = null!;

    public string PhotoSrc { get; set; } = null!;

    public virtual UserSneaker UserSneaker { get; set; } = null!;
}
