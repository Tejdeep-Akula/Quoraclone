using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuoraClone.Entities;

public partial class MyquoraDbContext : DbContext
{
    private readonly string connection;
    public MyquoraDbContext(string connection)
    {
        this.connection=connection;
    }

    public MyquoraDbContext(DbContextOptions<MyquoraDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(connection);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.Aid).HasName("PK__Answer__C6900628A72786EB");

            entity.ToTable("Answer");

            entity.Property(e => e.Aid).HasColumnName("AId");
            entity.Property(e => e.AcreatedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ACreatedBy");
            entity.Property(e => e.AcreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("ACreatedDateTime");
            entity.Property(e => e.Adescription)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("ADescription");
            entity.Property(e => e.AmodifiedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("AModifiedBy");
            entity.Property(e => e.AmodifiedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("AModifiedDateTime");

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__Answer__AModifie__619B8048");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Qid).HasName("PK__Question__CAB1462BDA58F477");

            entity.ToTable("Question");

            entity.Property(e => e.Qid).HasColumnName("QId");
            entity.Property(e => e.QcreatedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("QCreatedBy");
            entity.Property(e => e.QcreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("QCreatedDateTime");
            entity.Property(e => e.Qdescription)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("QDescription");
            entity.Property(e => e.QmodifiedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("QModifiedBy");
            entity.Property(e => e.QmodifiedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("QModifiedDateTime");

            entity.HasOne(d => d.Topic).WithMany(p => p.Questions)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK__Question__QModif__5EBF139D");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PK__Topic__022E0F5DB4BE9CD1");

            entity.ToTable("Topic");

            entity.Property(e => e.TcreatedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TCreatedBy");
            entity.Property(e => e.TcreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("TCreatedDateTime");
            entity.Property(e => e.TmodifiedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TModifiedBy");
            entity.Property(e => e.TmodifiedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("TModifiedDateTime");
            entity.Property(e => e.TopicDescription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TopicName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
