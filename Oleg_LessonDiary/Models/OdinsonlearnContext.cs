using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Oleg_LessonDiary;

public partial class OdinsonlearnContext : DbContext
{
    public OdinsonlearnContext()
    {
    }

    public OdinsonlearnContext(DbContextOptions<OdinsonlearnContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Direction> Directions { get; set; }

    public virtual DbSet<GuitarType> GuitarTypes { get; set; }

    public virtual DbSet<Journal> Journals { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=XCR6hs2M;database=odinsonlearn", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.HasKey(e => e.IdDirection).HasName("PRIMARY");

            entity.ToTable("direction");

            entity.Property(e => e.IdDirection).HasColumnName("id_direction");
            entity.Property(e => e.DirectionDescription)
                .HasColumnType("text")
                .HasColumnName("direction_description");
            entity.Property(e => e.DirectionName)
                .HasColumnType("text")
                .HasColumnName("direction_name");
        });

        modelBuilder.Entity<GuitarType>(entity =>
        {
            entity.HasKey(e => e.IdType).HasName("PRIMARY");

            entity.ToTable("guitar_types");

            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.TypeName)
                .HasColumnType("text")
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<Journal>(entity =>
        {
            entity.HasKey(e => e.IdJournal).HasName("PRIMARY");

            entity.ToTable("journal");

            entity.HasIndex(e => e.IdTecher, "fk_teacher_idx");

            entity.HasIndex(e => e.IdUser, "fk_users_idx");

            entity.Property(e => e.IdJournal).HasColumnName("id_journal");
            entity.Property(e => e.IdTecher).HasColumnName("id_techer");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.LessonDate).HasColumnName("lesson_date");
            entity.Property(e => e.LessonDecription)
                .HasColumnType("text")
                .HasColumnName("lesson_decription");

            entity.HasOne(d => d.IdTecherNavigation).WithMany(p => p.Journals)
                .HasForeignKey(d => d.IdTecher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_teacher");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Journals)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.IdTeacher).HasName("PRIMARY");

            entity.ToTable("teacher");

            entity.HasIndex(e => e.IdDirection, "fk_direction_idx");

            entity.Property(e => e.IdTeacher)
                .ValueGeneratedNever()
                .HasColumnName("id_teacher");
            entity.Property(e => e.IdDirection).HasColumnName("id_direction");
            entity.Property(e => e.TeacherLogin)
                .HasMaxLength(30)
                .HasColumnName("teacher_login");
            entity.Property(e => e.TeacherName)
                .HasMaxLength(30)
                .HasColumnName("teacher_name");
            entity.Property(e => e.TeacherPassword)
                .HasMaxLength(30)
                .HasColumnName("teacher_password");
            entity.Property(e => e.TeacherQualification)
                .HasMaxLength(20)
                .HasColumnName("teacher_qualification");
            entity.Property(e => e.TeacherSurname)
                .HasMaxLength(30)
                .HasColumnName("teacher_surname");

            entity.HasOne(d => d.IdDirectionNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.IdDirection)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_direction");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUsers).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.IdType, "fk_type_idx");

            entity.Property(e => e.IdUsers).HasColumnName("id_users");
            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.UserDatebirth).HasColumnName("user_datebirth");
            entity.Property(e => e.UserLogin)
                .HasMaxLength(30)
                .HasColumnName("user_login");
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .HasColumnName("user_name");
            entity.Property(e => e.UserPatronymics)
                .HasMaxLength(30)
                .HasColumnName("user_patronymics");
            entity.Property(e => e.UserSurname)
                .HasMaxLength(30)
                .HasColumnName("user_surname");
            entity.Property(e => e.UsersPassword)
                .HasMaxLength(30)
                .HasColumnName("users_password");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
