﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Oleg_LessonDiary.Data;

public partial class NewlearnContext : DbContext
{
    public NewlearnContext()
    {
    }

    public NewlearnContext(DbContextOptions<NewlearnContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Guitar> Guitars { get; set; }

    public virtual DbSet<Kur> Kurs { get; set; }

    public virtual DbSet<Learnplan> Learnplans { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userssubsription> Userssubsriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=XCR6hs2M;database=newlearn", ServerVersion.Parse("8.0.25-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Guitar>(entity =>
        {
            entity.HasKey(e => e.IdGuitar).HasName("PRIMARY");

            entity.ToTable("guitar");

            entity.Property(e => e.IdGuitar).HasColumnName("id_guitar");
            entity.Property(e => e.GuitarName)
                .HasMaxLength(45)
                .HasColumnName("guitar_name");
        });

        modelBuilder.Entity<Kur>(entity =>
        {
            entity.HasKey(e => e.IdKurs).HasName("PRIMARY");

            entity.ToTable("kurs");

            entity.HasIndex(e => e.KursIdGuitar, "kurs_id_guitar_fk_idx");

            entity.Property(e => e.IdKurs).HasColumnName("id_kurs");
            entity.Property(e => e.KursDuration).HasColumnName("kurs_duration");
            entity.Property(e => e.KursIdGuitar).HasColumnName("kurs_id_guitar");
            entity.Property(e => e.KursName)
                .HasMaxLength(45)
                .HasColumnName("kurs_name");

            entity.HasOne(d => d.KursIdGuitarNavigation).WithMany(p => p.Kurs)
                .HasForeignKey(d => d.KursIdGuitar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("kurs_id_guitar_fk");
        });

        modelBuilder.Entity<Learnplan>(entity =>
        {
            entity.HasKey(e => e.IdLearnPlan).HasName("PRIMARY");

            entity.ToTable("learnplan");

            entity.HasIndex(e => e.LearnPlanIdKurs, "teacherItem_id_kurs_fk_idx");

            entity.HasIndex(e => e.LearnPlanIdTeacher, "teacherItem_id_teacher_fk_idx");

            entity.Property(e => e.IdLearnPlan).HasColumnName("id_learnPlan");
            entity.Property(e => e.LearnPlanIdKurs).HasColumnName("learnPlan_id_kurs");
            entity.Property(e => e.LearnPlanIdTeacher).HasColumnName("learnPlan_id_teacher");
            entity.Property(e => e.LearnPlanRestriction).HasColumnName("learnPlan_restriction");

            entity.HasOne(d => d.LearnPlanIdKursNavigation).WithMany(p => p.Learnplans)
                .HasForeignKey(d => d.LearnPlanIdKurs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("learnPlan_id_kurs_fk");

            entity.HasOne(d => d.LearnPlanIdTeacherNavigation).WithMany(p => p.Learnplans)
                .HasForeignKey(d => d.LearnPlanIdTeacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("learnPlan_id_teacher_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUsers).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.IdUsers).HasColumnName("id_users");
            entity.Property(e => e.UsersDatebirth)
                .HasColumnType("datetime")
                .HasColumnName("users_datebirth");
            entity.Property(e => e.UsersLogin)
                .HasMaxLength(45)
                .HasColumnName("users_login");
            entity.Property(e => e.UsersName)
                .HasMaxLength(45)
                .HasColumnName("users_name");
            entity.Property(e => e.UsersPassword)
                .HasMaxLength(45)
                .HasColumnName("users_password");
            entity.Property(e => e.UsersPatronymics)
                .HasMaxLength(45)
                .HasColumnName("users_patronymics");
            entity.Property(e => e.UsersRole)
                .HasMaxLength(45)
                .HasColumnName("users_role");
            entity.Property(e => e.UsersSurname)
                .HasMaxLength(45)
                .HasColumnName("users_surname");
        });

        modelBuilder.Entity<Userssubsription>(entity =>
        {
            entity.HasKey(e => e.IdUserssubsription).HasName("PRIMARY");

            entity.ToTable("userssubsription");

            entity.HasIndex(e => e.UserssubsriptionIdUsers, "userssubsription_id_users_fk_idx");

            entity.Property(e => e.IdUserssubsription).HasColumnName("id_userssubsription");
            entity.Property(e => e.UserssubsriptionDate)
                .HasColumnType("datetime")
                .HasColumnName("userssubsription_date");
            entity.Property(e => e.UserssubsriptionIdUsers).HasColumnName("userssubsription_id_users");
            entity.Property(e => e.UserssubsriptionStatus)
                .HasMaxLength(45)
                .HasColumnName("userssubsription_status")
                .UseCollation("utf8mb4_bin");

            entity.HasOne(d => d.UserssubsriptionIdUsersNavigation).WithMany(p => p.Userssubsriptions)
                .HasForeignKey(d => d.UserssubsriptionIdUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userssubsription_id_users_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
