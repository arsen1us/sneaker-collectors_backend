using System;
using System.Collections.Generic;

namespace sneaker_collectors_backend.Models.Database;

public partial class User
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public int? Age { get; set; }

    public string Login { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string PhoroSrc { get; set; } = null!;
}
