using System;
using System.Collections.Generic;

namespace sneaker_collectors_backend;

public partial class SneakersState
{
    public string Id { get; set; } = null!;

    public string State { get; set; } = null!;

    public string SneakerId { get; set; } = null!;

    public virtual UserSneaker Sneaker { get; set; } = null!;
}
