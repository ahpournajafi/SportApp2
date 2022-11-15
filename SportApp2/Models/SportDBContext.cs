using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SportApp2.Models
{
    public partial class SportDBContext : DbContext
    {
        public SportDBContext()
        {
        }

        public SportDBContext(DbContextOptions<SportDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<ExamType> ExamTypes { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Period> Periods { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Subgroup> Subgroups { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("DataSource=SportDB.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Batch>(entity =>
            {
                entity.ToTable("Batch");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Batches)
                    .HasForeignKey(d => d.GroupId);

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.Batches)
                    .HasForeignKey(d => d.PeriodId);

                entity.HasOne(d => d.Subgroup)
                    .WithMany(p => p.Batches)
                    .HasForeignKey(d => d.SubgroupId);
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("Exam");

                entity.HasIndex(e => e.ExamtypeId, "IX_Exam_ExamtypeId");

                entity.HasIndex(e => e.PersonId, "IX_Exam_PersonId");

                entity.HasOne(d => d.Examtype)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.ExamtypeId);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.PersonId);
            });

            modelBuilder.Entity<ExamType>(entity =>
            {
                entity.ToTable("ExamType");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");
            });

            modelBuilder.Entity<Period>(entity =>
            {
                entity.ToTable("Period");

                entity.HasIndex(e => e.GroupId, "IX_Period_GroupId");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Periods)
                    .HasForeignKey(d => d.GroupId);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.HasIndex(e => e.GroupId, "IX_Person_GroupId");

                entity.HasIndex(e => e.PeriodId, "IX_Person_PeriodId");

                entity.HasIndex(e => e.SubgroupId, "IX_Person_SubgroupId");

                entity.HasIndex(e => e.BatcheId, "IX_Person_batcheId");

                entity.Property(e => e.BatcheId).HasColumnName("batcheId");

                entity.HasOne(d => d.Batche)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.BatcheId);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.GroupId);

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.PeriodId);

                entity.HasOne(d => d.Subgroup)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.SubgroupId);
            });

            modelBuilder.Entity<Subgroup>(entity =>
            {
                entity.ToTable("Subgroup");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Subgroups)
                    .HasForeignKey(d => d.GroupId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
