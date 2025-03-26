using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace TodoApi;

public partial class ToDoDB : DbContext
{
     //connectionString = "server=bvktjohaal8zegx4szfp-mysql.services.clever-cloud.com;user=umnezn53mliirmkb;password=ttlQGolvaYooFYT5x2Z1;database=bvktjohaal8zegx4szfp";

    public ToDoDB()
    {
    }

    public ToDoDB(DbContextOptions<ToDoDB> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=bvktjohaal8zegx4szfp-mysql.services.clever-cloud.com;user=umnezn53mliirmkb;password=ttlQGolvaYooFYT5x2Z1;database=bvktjohaal8zegx4szfp", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.41-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("items");

            entity.HasIndex(e => e.Id, "Id_UNIQUE").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
