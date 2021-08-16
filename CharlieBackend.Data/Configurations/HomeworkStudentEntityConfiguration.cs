﻿using CharlieBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CharlieBackend.Data.Configurations
{
    class HomeworkStudentEntityConfiguration
        : IEntityTypeConfiguration<HomeworkStudent>
    {
        public void Configure(EntityTypeBuilder<HomeworkStudent> entity)
        {
            entity.ToTable("homework_from_student");

            entity.HasIndex(e => new { e.HomeworkId }).HasName("homework_id");

            entity.Property(e => e.Id).HasColumnName("Id");

            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.Property(e => e.HomeworkId).HasColumnName("homework_id");

            entity.Property(e => e.HomeworkText)
                .HasColumnName("homework_text")
                .HasColumnType("varchar(4000)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.MarkId)
                .HasColumnName("mark_id")
                .HasColumnType("BIGINT");

            entity.Property(e => e.PublishingDate)
                .HasColumnName("publishing_date")
                .HasColumnType("DATETIME")
                .IsRequired();

            entity.Property(e => e.IsSent)
                .HasColumnName("is_sent")
                .HasColumnType("TINYINT(1)")
                .IsRequired();

            entity.HasOne(h => h.Mark)
                .WithOne(s => s.HomeworkStudent)
                .HasForeignKey<HomeworkStudent>(h => h.MarkId)
                .HasConstraintName("FK_mark_of_homework");

            entity.HasOne(h => h.Homework)
                .WithMany(h => h.HomeworkStudents)
                .HasForeignKey(h => h.HomeworkId)
                .HasConstraintName("FK_student_homework");

            entity.HasOne(h => h.Student)
                .WithMany(s => s.HomeworkStudents)
                .HasForeignKey(h => h.StudentId)
                .HasConstraintName("FK_homework_of_student");
        }
    }
}
