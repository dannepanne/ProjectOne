using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectOne.Models
{
    public partial class ProjectDBexaContext : DbContext
    {
        public ProjectDBexaContext()
        {
        }

        public ProjectDBexaContext(DbContextOptions<ProjectDBexaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectTask> ProjectTasks { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ProjectDBexa;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("active")
                    .IsFixedLength();

                entity.Property(e => e.Customer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("customer");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.DueDate)
                    .HasColumnType("date")
                    .HasColumnName("due_date");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<ProjectTask>(entity =>
            {
                entity.ToTable("Project_tasks");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Resourceid).HasColumnName("resourceid");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectTasks)
                    .HasForeignKey(d => d.Projectid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Project_tasks_Projects");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.ProjectTasks)
                    .HasForeignKey(d => d.Resourceid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Project_tasks_Resources");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdminRights)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("admin_rights")
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.Skill)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("skill");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
