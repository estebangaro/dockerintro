using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace Models.Data;

public partial class PruebasContext : DbContext
{
    public PruebasContext()
    {
    }

    public PruebasContext(DbContextOptions<PruebasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Counter> Counters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=pruebas;User Id=sa;Password=M45T3R3D104#;TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Counter>(entity =>
        {
            entity.ToTable("counters");

            entity.Property(e => e.Id);
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Createdate)
                .HasColumnType("datetime")
                .HasColumnName("createdate");
            entity.Property(e => e.Lastupdatedate)
                .HasColumnType("datetime")
                .HasColumnName("lastupdatedate");
            entity.Property(e => e.Tag)
                .HasMaxLength(125)
                .HasColumnName("tag");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
