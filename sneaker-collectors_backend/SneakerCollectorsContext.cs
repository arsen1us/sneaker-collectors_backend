using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using sneaker_collectors_backend.Models.Database;

namespace sneaker_collectors_backend;

public partial class SneakerCollectorsContext : DbContext
{
    public SneakerCollectorsContext()
    {
    }

    public SneakerCollectorsContext(DbContextOptions<SneakerCollectorsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<BrandFounder> BrandFounders { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NewsHashtag> NewsHashtags { get; set; }

    public virtual DbSet<NewsPhoto> NewsPhotos { get; set; }

    public virtual DbSet<SneakerMaterial> SneakerMaterials { get; set; }

    public virtual DbSet<SneakerPurpose> SneakerPurposes { get; set; }

    public virtual DbSet<SneakerSample> SneakerSamples { get; set; }

    public virtual DbSet<SneakerSamplesPhoto> SneakerSamplesPhotos { get; set; }

    public virtual DbSet<SneakersState> SneakersStates { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserSneaker> UserSneakers { get; set; }

    public virtual DbSet<UserSneakersPhoto> UserSneakersPhotos { get; set; }

    public virtual DbSet<SneakerColor> SneakersColors { get; set; }

    public virtual DbSet<SneakerTechnology> SneakerTechnologies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-9RTLIH5;Initial Catalog=sneaker_collectors;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Таблица с информацией о брендах

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__brands__3213E83FCF3DEB8C");

            entity.ToTable("brands");

            entity.HasIndex(e => e.Id, "UQ__brands__3213E83E360AA9F1").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Country)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.History)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("history");
            entity.Property(e => e.LogoSrc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("./images/default_brand_logo.png")
                .HasColumnName("logo_src");
            entity.Property(e => e.OfficialSiteUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("official_site_url");
        });
        // Таблица с информацией об основателях брендов

        modelBuilder.Entity<BrandFounder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__brand_fo__3213E83F609ADA79");

            entity.ToTable("brand_founders");

            entity.HasIndex(e => e.Id, "UQ__brand_fo__3213E83E35771AF1").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.BornIn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("born_in");
            entity.Property(e => e.BrandId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("brand_id");
            entity.Property(e => e.DiedIn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("died_in");
            entity.Property(e => e.History)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("history");
            entity.Property(e => e.PhotoSrc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("./images/default_user_photo.png")
                .HasColumnName("photo_src");

            entity.HasOne(d => d.Brand).WithMany(p => p.BrandFounders)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__brand_fou__died___59FA5E80");
        });
        // Таблица с информацией о новостях

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__news__3213E83F16D140B9");

            entity.ToTable("news");

            entity.HasIndex(e => e.Id, "UQ__news__3213E83E69B4EF9B").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Author)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("not specified")
                .HasColumnName("author");
            entity.Property(e => e.Body)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("body");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("update_at");
        });
        // Таблица с тегами для новостей

        modelBuilder.Entity<NewsHashtag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__news_has__3213E83F743C7805");

            entity.ToTable("news_hashtags");

            entity.HasIndex(e => e.Id, "UQ__news_has__3213E83E6B8B89FE").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Hashtag)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("hashtag");
            entity.Property(e => e.NewsId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("news_id");

            entity.HasOne(d => d.News).WithMany(p => p.NewsHashtags)
                .HasForeignKey(d => d.NewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__news_hash__hasht__06CD04F7");
        });
        // Таблица с фото для новостей

        modelBuilder.Entity<NewsPhoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__news_pho__3213E83F4F070DEA");

            entity.ToTable("news_photo");

            entity.HasIndex(e => e.Id, "UQ__news_pho__3213E83EC98B8B27").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.NewsId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("news_id");
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("./images/news_white_background.png")
                .HasColumnName("photo_url");

            entity.HasOne(d => d.News).WithMany(p => p.NewsPhotos)
                .HasForeignKey(d => d.NewsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__news_phot__photo__0B91BA14");
        });
        // Таблица с материалами шаблонов кроссовок

        modelBuilder.Entity<SneakerMaterial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sneaker___3213E83F682CB5D4");

            entity.ToTable("sneaker_materials");

            entity.HasIndex(e => e.Id, "UQ__sneaker___3213E83E7E466882").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.InsideMaterial)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValue("not specified")
                .HasColumnName("inside_material");
            entity.Property(e => e.InsoleMaterial)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValue("not specified")
                .HasColumnName("insole_material");
            entity.Property(e => e.SneakerId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("sneaker_id");
            entity.Property(e => e.SoleMaterial)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValue("not specified")
                .HasColumnName("sole_material");
            entity.Property(e => e.UpMaterial)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValue("not specified")
                .HasColumnName("up_material");

            entity.HasOne(d => d.Sneaker).WithMany(p => p.SneakerMaterials)
                .HasForeignKey(d => d.SneakerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sneaker_m__insol__74AE54BC");
        });
        // Таблица с предназначением кроссовок

        modelBuilder.Entity<SneakerPurpose>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sneaker___3213E83F3AC63A98");

            entity.ToTable("sneaker_purpose");

            entity.HasIndex(e => e.Id, "UQ__sneaker___3213E83E30F6554B").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Purpose)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("purpose");
            entity.Property(e => e.SneakerSampleId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("sneaker_sample_id");

            entity.HasOne(d => d.SneakerSample).WithMany(p => p.SneakerPurposes)
                .HasForeignKey(d => d.SneakerSampleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sneaker_p__purpo__7D439ABD");
        });
        // Таблица с шаблонами кроссовок

        modelBuilder.Entity<SneakerSample>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sneaker___3213E83F8CAAB33B");

            entity.ToTable("sneaker_samples");

            entity.HasIndex(e => e.Id, "UQ__sneaker___3213E83EDA7D1AC6").IsUnique();


            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.BrandId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("brand_id");
            entity.Property(e => e.ColorId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("not specified")
                .HasColumnName("color_id");
            entity.Property(e => e.Discription)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValue("not specified")
                .HasColumnName("discription");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("model");
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gender")
                .HasDefaultValue("do not specify");

            entity.HasOne(d => d.Color)
                .WithOne(p => p.SneakerSample)
                .HasForeignKey<SneakerSample>(d => d.ColorId)
                .HasConstraintName("FK__sneaker_s__color__540C7B00");
        });
        // Таблица с фото шаблонов кроссовок

        modelBuilder.Entity<SneakerSamplesPhoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sneaker___3213E83F26933E5A");

            entity.ToTable("sneaker_samples_photos");

            entity.HasIndex(e => e.Id, "UQ__sneaker___3213E83E06BF6E58").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.PhotoSrc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("photo_src");
            entity.Property(e => e.SneakerSampleId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasDefaultValue("./images/default_sneaker_photo.png")
                .HasColumnName("sneaker_sample_id");

            entity.HasOne(d => d.SneakerSample).WithMany(p => p.SneakerSamplesPhotos)
                .HasForeignKey(d => d.SneakerSampleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sneaker_s__photo__6D0D32F4");
        });
        // Таблица с состоянием кроссовок пользователей

        modelBuilder.Entity<SneakersState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sneakers__3213E83F15B6D452");

            entity.ToTable("sneakers_state");

            entity.HasIndex(e => e.Id, "UQ__sneakers__3213E83E9632E974").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.SneakerId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("sneaker_id");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("not specified")
                .HasColumnName("state");

            entity.HasOne(d => d.Sneaker).WithMany(p => p.SneakersStates)
                .HasForeignKey(d => d.SneakerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sneakers___sneak__797309D9");
        });
        // Таблица с цветами шаблонов кроссовок

        modelBuilder.Entity<SneakerColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sneaker___3213E83FF693A941");
            entity.ToTable("sneaker_colors");
            entity.HasIndex(e => e.Id, "UQ__sneaker___3213E83E3F53FC7F").IsUnique();
            entity.HasIndex(e => e.Color, "UQ__sneaker___900DC6E91E7D104D").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");

            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("color");

            entity.HasOne(d => d.SneakerSample)
                .WithOne(p => p.Color)
                .HasForeignKey<SneakerSample>(d => d.ColorId);
        });
        // Таблица с технологиями кроссовок

        modelBuilder.Entity<SneakerTechnology>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sneakers__3213E83FA82AC8A9");
            entity.ToTable("sneakers_technologies");
            entity.HasIndex(e => e.Id, "UQ__sneakers__3213E83E3FB86B78").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");

            entity.Property(e => e.Technology)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("technology)")
                .HasDefaultValue("do not specify");

            entity.Property(e => e.SneakerId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("sneaker_id)");

            entity.HasOne(d => d.SneakerSample)
                .WithMany(p => p.SneakerTechnologies)
                .HasForeignKey(d => d.SneakerId)
                .HasConstraintName("FK__sneakers___techn__58D1301D");
        });
        // Таблица с пользователями

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F4DD14C9B");

            entity.ToTable("users");

            entity.HasIndex(e => e.Id, "UQ__users__3213E83E6B6E2854").IsUnique();

            entity.HasIndex(e => e.Login, "UQ__users__7838F27258646B67").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__users__AB6E6164852E06EE").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Email)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(24)
                .IsUnicode(false)
                .HasDefaultValue("do not specify")
                .HasColumnName("gender");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValue("do not specify")
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoroSrc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("./images/default_user_photo.png")
                .HasColumnName("phoro_src");
            entity.Property(e => e.Surname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasDefaultValue("do not specify")
                .HasColumnName("surname");
        });
        // Таблица с кроссовками пользователей

        modelBuilder.Entity<UserSneaker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_sne__3213E83FD6D4CB6D");

            entity.ToTable("user_sneakers");

            entity.HasIndex(e => e.Id, "UQ__user_sne__3213E83EE88219DB").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.BrandId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("brand_id");
            entity.Property(e => e.Discription)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("discription");
            entity.Property(e => e.Mileage).HasColumnName("mileage");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("model");
            entity.Property(e => e.Season)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("season");
            entity.Property(e => e.Size).HasColumnName("size");

            entity.HasOne(d => d.Brand).WithMany(p => p.UserSneakers)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_snea__seaso__5EBF139D");
        });
        // Таблица с фото кроссовок пользователей

        modelBuilder.Entity<UserSneakersPhoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_sne__3213E83F5BC52704");

            entity.ToTable("user_sneakers_photos");

            entity.HasIndex(e => e.Id, "UQ__user_sne__3213E83E19817319").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.PhotoSrc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("photo_src");
            entity.Property(e => e.UserSneakerId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasDefaultValue("./images/default_sneaker_photo.png")
                .HasColumnName("user_sneaker_id");

            entity.HasOne(d => d.UserSneaker).WithMany(p => p.UserSneakersPhotos)
                .HasForeignKey(d => d.UserSneakerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_snea__photo__68487DD7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
