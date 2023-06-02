using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Oleg_LessonDiary.Data;

public partial class OdinsonlearnContext : DbContext
{
    public OdinsonlearnContext()
    {
    }

    public OdinsonlearnContext(DbContextOptions<OdinsonlearnContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Degree> Degrees { get; set; }

    public virtual DbSet<Direction> Directions { get; set; }

    public virtual DbSet<GuitarType> GuitarTypes { get; set; }

    public virtual DbSet<Journal> Journals { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=XCR6hs2M;database=odinsonlearn", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Degree>(entity =>
        {
            entity.HasKey(e => e.IdDegree).HasName("PRIMARY");

            entity.ToTable("degrees");

            entity.Property(e => e.IdDegree)
                .ValueGeneratedNever()
                .HasColumnName("id_degree");
            entity.Property(e => e.DegreeName)
                .HasMaxLength(45)
                .HasColumnName("degree_name");
        });

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.HasKey(e => e.IdDirection).HasName("PRIMARY");

            entity.ToTable("directions");

            entity.Property(e => e.IdDirection).HasColumnName("id_direction");
            entity.Property(e => e.DirectionName)
                .HasMaxLength(45)
                .HasColumnName("direction_name");
        });

        modelBuilder.Entity<GuitarType>(entity =>
        {
            entity.HasKey(e => e.IdGuitarType).HasName("PRIMARY");

            entity.ToTable("guitar_types");

            entity.Property(e => e.IdGuitarType).HasColumnName("id_guitar_type");
            entity.Property(e => e.TypeName)
                .HasMaxLength(45)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<Journal>(entity =>
        {
            entity.HasKey(e => e.LessonId).HasName("PRIMARY");

            entity.ToTable("journal");

            entity.HasIndex(e => e.JournalTeacherId, "tr_journal_fk_idx");

            entity.HasIndex(e => e.JournalUserId, "user_journal_fk_idx");

            entity.Property(e => e.LessonId).HasColumnName("lesson_id");
            entity.Property(e => e.JournalTeacherId).HasColumnName("journal_teacher_id");
            entity.Property(e => e.JournalUserId).HasColumnName("journal_user_id");
            entity.Property(e => e.LessonDate).HasColumnName("lesson_date");
            entity.Property(e => e.LessonDescription).HasColumnName("lesson_description");

            entity.HasOne(d => d.JournalTeacher).WithMany(p => p.Journals)
                .HasForeignKey(d => d.JournalTeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tr_journal_fk");

            entity.HasOne(d => d.JournalUser).WithMany(p => p.Journals)
                .HasForeignKey(d => d.JournalUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_journal_fk");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.IdTeacher).HasName("PRIMARY");

            entity.ToTable("teacher");

            entity.HasIndex(e => e.TrDegree, "tr_degree_fk_idx");

            entity.HasIndex(e => e.TrDirection, "tr_direction_fk_idx");

            entity.Property(e => e.IdTeacher).HasColumnName("id_teacher");
            entity.Property(e => e.TrDegree).HasColumnName("tr_degree");
            entity.Property(e => e.TrDirection).HasColumnName("tr_direction");
            entity.Property(e => e.TrLogin)
                .HasMaxLength(50)
                .HasColumnName("tr_login");
            entity.Property(e => e.TrName)
                .HasMaxLength(45)
                .HasColumnName("tr_name");
            entity.Property(e => e.TrPassword)
                .HasMaxLength(50)
                .HasColumnName("tr_password");
            entity.Property(e => e.TrPatronymics)
                .HasMaxLength(45)
                .HasColumnName("tr_patronymics");
            entity.Property(e => e.TrSurname)
                .HasMaxLength(45)
                .HasColumnName("tr_surname");

            entity.HasOne(d => d.TrDegreeNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.TrDegree)
                .HasConstraintName("tr_degree_fk");

            entity.HasOne(d => d.TrDirectionNavigation).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.TrDirection)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tr_direction_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUsers).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.IdType, "user_guitar_fk_idx");

            entity.Property(e => e.IdUsers).HasColumnName("id_users");
            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.UserDatebirth).HasColumnName("user_datebirth");
            entity.Property(e => e.UserLogin)
                .HasMaxLength(45)
                .HasColumnName("user_login");
            entity.Property(e => e.UserName)
                .HasMaxLength(45)
                .HasColumnName("user_name");
            entity.Property(e => e.UserPatronymics)
                .HasMaxLength(45)
                .HasColumnName("user_patronymics");
            entity.Property(e => e.UserSurname)
                .HasMaxLength(45)
                .HasColumnName("user_surname");
            entity.Property(e => e.UsersPassword)
                .HasMaxLength(45)
                .HasColumnName("users_password");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_guitar_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
