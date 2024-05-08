using System;
using System.Collections.Generic;
using APIBurger_DanielaMora.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace APIBurger_DanielaMora.Data;

public partial class DanielaMoraTercerTallerContextA624bf8eBcda48bc8bc921bf57f2673fContext : DbContext
{
    public DanielaMoraTercerTallerContextA624bf8eBcda48bc8bc921bf57f2673fContext()
    {
    }

    public DanielaMoraTercerTallerContextA624bf8eBcda48bc8bc921bf57f2673fContext(DbContextOptions<DanielaMoraTercerTallerContextA624bf8eBcda48bc8bc921bf57f2673fContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Burger> Burgers { get; set; }

    public virtual DbSet<Promo> Promos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DanielaMoraTercerTallerContext-a624bf8e-bcda-48bc-8bc9-21bf57f2673f;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Burger>(entity =>
        {
            entity.ToTable("Burger");

            entity.Property(e => e.BurgerId).HasColumnName("BurgerID");
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Promo>(entity =>
        {
            entity.ToTable("Promo");

            entity.HasIndex(e => e.BurgerId, "IX_Promo_BurgerID");

            entity.Property(e => e.PromoId).HasColumnName("PromoID");
            entity.Property(e => e.BurgerId).HasColumnName("BurgerID");

            entity.HasOne(d => d.Burger).WithMany(p => p.Promos).HasForeignKey(d => d.BurgerId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
