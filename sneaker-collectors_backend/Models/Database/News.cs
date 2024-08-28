using System;
using System.Collections.Generic;

namespace sneaker_collectors_backend.Models.Database;

public partial class News
{
    public string Id { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Body { get; set; } = null!;

    public string Author { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdateAt { get; set; }

    public virtual ICollection<NewsHashtag> NewsHashtags { get; set; } = new List<NewsHashtag>();

    public virtual ICollection<NewsPhoto> NewsPhotos { get; set; } = new List<NewsPhoto>();
}
