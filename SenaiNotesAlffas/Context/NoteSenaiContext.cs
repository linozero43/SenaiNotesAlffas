using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SenaiNotesAlffas.Models;

namespace SenaiNotesAlffas.Context;

public partial class NoteSenaiContext : DbContext
{
    public NoteSenaiContext()
    {
    }

    private IConfiguration _configuration;

    public NoteSenaiContext(DbContextOptions<NoteSenaiContext> options ,IConfiguration config)
        : base(options)
    {
        _configuration = config;
    }

    public virtual DbSet<Anotacao> Anotacoes { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var con = _configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer("con");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anotacao>(entity =>
        {
            entity.HasKey(e => e.Idanotacoes).HasName("PK__Anotacoe__1387B2522413DE93");

            entity.Property(e => e.Idanotacoes).HasColumnName("IDAnotacoes");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Idstatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("IDStatus");
            entity.Property(e => e.Idtag).HasColumnName("IDTag");
            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.IsArchived).HasDefaultValue(false);
            entity.Property(e => e.Texto).HasColumnType("text");
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdtagNavigation).WithMany(p => p.Anotacoes)
                .HasForeignKey(d => d.Idtag)
                .HasConstraintName("FK__Anotacoes__IDTag__412EB0B6");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Anotacoes)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Anotacoes__IDUsu__403A8C7D");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Idtag).HasName("PK__Tag__A702375195FD3962");

            entity.ToTable("Tag");

            entity.Property(e => e.Idtag).HasColumnName("IDTag");
            entity.Property(e => e.Nome)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__Usuario__5231116945666C6E");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D1053468E6046D").IsUnique();

            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    internal void FirstOrDefault(Func<object, bool> value)
    {
        throw new NotImplementedException();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
