using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StartLab6.Models;

public partial class CAspnetcoreStartlab6Startlab6AppDataKunden2MdfContext : DbContext
{
    public CAspnetcoreStartlab6Startlab6AppDataKunden2MdfContext()
    {
    }

    public CAspnetcoreStartlab6Startlab6AppDataKunden2MdfContext(DbContextOptions<CAspnetcoreStartlab6Startlab6AppDataKunden2MdfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auftrag> Auftrags { get; set; }

    public virtual DbSet<Kunde> Kundes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\aspnetcore\\StartLab6\\StartLab6\\app_data\\kunden2.mdf;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auftrag>(entity =>
        {
            entity.HasKey(e => e.AuftragId).HasName("PK__Auftrag__8686951E62F3AD7F");

            entity.ToTable("Auftrag");

            entity.Property(e => e.Datum).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Titel)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Kunde).WithMany(p => p.Auftrags)
                .HasForeignKey(d => d.KundeId)
                .HasConstraintName("FK__Auftrag__KundeId__398D8EEE");
        });

        modelBuilder.Entity<Kunde>(entity =>
        {
            entity.HasKey(e => e.KundeId).HasName("PK__Kunde__7F871DC1959D41D1");

            entity.ToTable("Kunde");

            entity.Property(e => e.Datum).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Land)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ort)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Plz)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("PLZ");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
