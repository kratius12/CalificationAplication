using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Models;

public partial class RickymortyContext : IdentityDbContext<IdentityUser>
{
    internal static readonly object Personaje;

    public RickymortyContext()
    {
    }

    public RickymortyContext(DbContextOptions<RickymortyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Personaje> Personajes { get; set; }

    public virtual DbSet<Ranking> Rankings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=rickymorty;integrated security=True; TrustServerCertificate=True");



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
        modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
        modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();




        modelBuilder.Entity<Personaje>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__personaj__3213E83F604CD0F1");

            entity.ToTable("personaje");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Especie)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("especie");
            entity.Property(e => e.Genero)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Ranking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ranking__3213E83FF181D4C9");

            entity.ToTable("ranking");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calificacion).HasColumnName("calificacion");
            entity.Property(e => e.IdPer).HasColumnName("idPer");

            entity.HasOne(d => d.IdPerNavigation).WithMany(p => p.Rankings)
                .HasForeignKey(d => d.IdPer)
                .HasConstraintName("FK_idPer");
        });
       
        ;
    }
        

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
