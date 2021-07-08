using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CorporateQualitySolution.Models.DB
{
    public partial class QualityManagementContext : DbContext
    {
        public QualityManagementContext()
        {
        }

        public QualityManagementContext(DbContextOptions<QualityManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAccountBusinessUnitMapping> TblAccountBusinessUnitMappings { get; set; }
        public virtual DbSet<TblAccountMaster> TblAccountMasters { get; set; }
        public virtual DbSet<TblBusinessUnitMaster> TblBusinessUnitMasters { get; set; }
        public virtual DbSet<TblLocationMaster> TblLocationMasters { get; set; }
        public virtual DbSet<TblProjectAccountMapping> TblProjectAccountMappings { get; set; }
        public virtual DbSet<TblProjectMaster> TblProjectMasters { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=LAP-01-4702;Database=QualityManagement;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblAccountBusinessUnitMapping>(entity =>
            {
                entity.ToTable("tblAccountBusinessUnitMapping");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TblAccountBusinessUnitMappings)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAccountBusinessUnitMapping_tblAccountMaster");

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.TblAccountBusinessUnitMappings)
                    .HasForeignKey(d => d.BusinessUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAccountBusinessUnitMapping_tblBusinessUnitMaster");
            });

            modelBuilder.Entity<TblAccountMaster>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("tblAccountMaster");

                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.Property(e => e.AccountCode).HasMaxLength(50);

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DisplayAccountName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblBusinessUnitMaster>(entity =>
            {
                entity.HasKey(e => e.BusinessUnitId);

                entity.ToTable("tblBusinessUnitMaster");

                entity.Property(e => e.BusinessUnitId).ValueGeneratedNever();

                entity.Property(e => e.BusinessUnitName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BusinessUnitShortName).HasMaxLength(10);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblLocationMaster>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.ToTable("tblLocationMaster");

                entity.Property(e => e.LocationId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblProjectAccountMapping>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblProjectAccountMapping");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.HasOne(d => d.Account)
                    .WithMany()
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProjectAccountMapping_tblAccountMaster");

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany()
                    .HasForeignKey(d => d.BusinessUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProjectAccountMapping_tblBusinessUnitMaster");

                entity.HasOne(d => d.Location)
                    .WithMany()
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProjectAccountMapping_tblLocationMaster");

                entity.HasOne(d => d.Project)
                    .WithMany()
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblProjectAccountMapping_tblProjectMaster");
            });

            modelBuilder.Entity<TblProjectMaster>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.ToTable("tblProjectMaster");

                entity.Property(e => e.ProjectId).ValueGeneratedNever();

                entity.Property(e => e.ProjectCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProjectDesc)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
