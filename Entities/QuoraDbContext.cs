using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuoraClone.Entities;

public partial class QuoraDbContext : DbContext
{
    private readonly string connectionString;
    public QuoraDbContext(string connection)
    {
        connectionString=connection;
    }

    public QuoraDbContext(DbContextOptions<QuoraDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(connectionString);
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.Aid).HasName("PK__Answer__C6970A107D85706E");

            entity.ToTable("Answer");

            entity.Property(e => e.AcreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AcreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.Adescription)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.AmodifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AmodifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__Answer__Question__3E52440B");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Qid).HasName("PK__Question__CAB64A037FFFD5F1");

            entity.ToTable("Question");

            entity.Property(e => e.QcreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QcreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.Qdescription)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.QmodifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QmodifiedDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Topic).WithMany(p => p.Questions)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK__Question__TopicI__3D5E1FD2");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PK__Topic__022E0F5D6D1817B7");

            entity.ToTable("Topic");

            entity.Property(e => e.TcreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TcreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.TmodifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TmodifiedDateTime).HasColumnType("datetime");
            entity.Property(e => e.TopicDescription)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.TopicName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
