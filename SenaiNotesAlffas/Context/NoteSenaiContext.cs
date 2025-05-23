using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SenaiNotesAlffas.Models;

namespace SenaiNotesAlffas.Context;

public partial class NoteSenaiContext : DbContext
{
    public NoteSenaiContext()
    {
    }
    private IConfiguration _configuration;

    public NoteSenaiContext(DbContextOptions<NoteSenaiContext> options, IConfiguration config)
        : base(options)
    {
        _configuration = config;
    }

    public virtual DbSet<Anotacao> Anotacoes { get; set; }

    public virtual DbSet<AuditoriaGeral> AuditoriaGerals { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var con = _configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(con);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anotacao>(entity =>
        {
            entity.HasKey(e => e.Idanotacoes).HasName("PK__Anotacoe__1387B252ED3CFAF8");

            entity.Property(e => e.Idanotacoes).HasColumnName("IDAnotacoes");
            entity.Property(e => e.AtualizadorAt).HasColumnType("datetime");
            entity.Property(e => e.CriadorAt).HasColumnType("datetime");
            entity.Property(e => e.Idstatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("IDStatus");
            entity.Property(e => e.Idtag).HasColumnName("IDTag");
            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.Texto).HasColumnType("text");
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdtagNavigation).WithMany(p => p.Anotacoes)
                .HasForeignKey(d => d.Idtag)
                .HasConstraintName("FK__Anotacoes__IDTag__66603565");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Anotacoes)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Anotacoes__IDUsu__656C112C");

            entity.HasMany(d => d.Idtags).WithMany(p => p.Idanotacoes)
                .UsingEntity<Dictionary<string, object>>(
                    "AnotacaoTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("Idtag")
                        .HasConstraintName("FK__AnotacaoT__IDTag__0D7A0286"),
                    l => l.HasOne<Anotacao>().WithMany()
                        .HasForeignKey("Idanotacao")
                        .HasConstraintName("FK__AnotacaoT__IDAno__0C85DE4D"),
                    j =>
                    {
                        j.HasKey("Idanotacao", "Idtag").HasName("PK__Anotacao__4279B88E58235366");
                        j.ToTable("AnotacaoTag");
                        j.IndexerProperty<int>("Idanotacao").HasColumnName("IDAnotacao");
                        j.IndexerProperty<int>("Idtag").HasColumnName("IDTag");
                    });
        });

        modelBuilder.Entity<AuditoriaGeral>(entity =>
        {
            entity.HasKey(e => e.AuditoriaId).HasName("PK__Auditori__095694E32412991B");

            entity.ToTable("AuditoriaGeral");

            entity.Property(e => e.AuditoriaId).HasColumnName("AuditoriaID");
            entity.Property(e => e.DataAcao).HasColumnType("datetime");
            entity.Property(e => e.NomeTabela)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TipoAcao)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Usuario)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Idtag).HasName("PK__Tag__A7023751ED1D35A0");

            entity.ToTable("Tag", tb => tb.HasTrigger("trg_Audit_Tags"));

            entity.Property(e => e.Idtag).HasColumnName("IDTag");
            entity.Property(e => e.Nome)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("PK__Usuario__523111693EBCF429");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534271641C5").IsUnique();

            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.CriadorAt).HasColumnType("datetime");
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

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
