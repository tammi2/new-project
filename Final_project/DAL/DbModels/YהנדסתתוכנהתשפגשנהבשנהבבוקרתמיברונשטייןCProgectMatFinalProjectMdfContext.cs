using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.DbModels;

public partial class YהנדסתתוכנהתשפגשנהבשנהבבוקרתמיברונשטייןCProgectMatFinalProjectMdfContext : DbContext
{
    public YהנדסתתוכנהתשפגשנהבשנהבבוקרתמיברונשטייןCProgectMatFinalProjectMdfContext()
    {
    }

    public YהנדסתתוכנהתשפגשנהבשנהבבוקרתמיברונשטייןCProgectMatFinalProjectMdfContext(DbContextOptions<YהנדסתתוכנהתשפגשנהבשנהבבוקרתמיברונשטייןCProgectMatFinalProjectMdfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Y:\\הנדסת תוכנה-תשפג\\שנה ב\\שנה ב בוקר\\תמי ברונשטיין\\c#\\progect mat\\final_project.mdf;Trusted_Connection=True;trustserverCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(entity =>
        {
            entity.Property(e => e.TaskId).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.TaskTital)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.User).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Tasks_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.LoginName, "IX_Users").IsUnique();

            entity.Property(e => e.ALevel).HasColumnName("A_level");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.LoginName)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
