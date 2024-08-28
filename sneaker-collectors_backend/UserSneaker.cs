using System;
using System.Collections.Generic;

namespace sneaker_collectors_backend;

public partial class UserSneaker
{
    public string Id { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Discription { get; set; } = null!;

    public string BrandId { get; set; } = null!;

    public double Size { get; set; }

    public double Mileage { get; set; }

    public string? Season { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<SneakersState> SneakersStates { get; set; } = new List<SneakersState>();

    public virtual ICollection<UserSneakersPhoto> UserSneakersPhotos { get; set; } = new List<UserSneakersPhoto>();
}
