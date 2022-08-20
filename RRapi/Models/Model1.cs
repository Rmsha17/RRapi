using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace RRapi.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Artifact> Artifacts { get; set; }
        public virtual DbSet<Bookmark> Bookmarks { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Episode> Episodes { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Notificaton> Notificatons { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order_Details> Order_Details { get; set; }
        public virtual DbSet<Premium> Premiums { get; set; }
        public virtual DbSet<Reader> Readers { get; set; }
        public virtual DbSet<ReaderPremium> ReaderPremiums { get; set; }
        public virtual DbSet<SalaryRate> SalaryRates { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<ShopArtifact> ShopArtifacts { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<View> Views { get; set; }
        public virtual DbSet<WEBSITE_DETAILS> WEBSITE_DETAILS { get; set; }
        public virtual DbSet<Withdraw_Amount> Withdraw_Amount { get; set; }
        public virtual DbSet<Writer> Writers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .HasMany(e => e.Writers)
                .WithRequired(e => e.Admin)
                .HasForeignKey(e => e.ADMIN_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Artifact>()
                .HasMany(e => e.Bookmarks)
                .WithRequired(e => e.Artifact)
                .HasForeignKey(e => e.ARTIFACT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Artifact>()
                .HasMany(e => e.Episodes)
                .WithRequired(e => e.Artifact)
                .HasForeignKey(e => e.ARTIFACT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Artifact>()
                .HasMany(e => e.Feedbacks)
                .WithRequired(e => e.Artifact)
                .HasForeignKey(e => e.ARTIFACT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Artifact>()
                .HasMany(e => e.ShopArtifacts)
                .WithOptional(e => e.Artifact)
                .HasForeignKey(e => e.ARTIFACT_FID);

            modelBuilder.Entity<Artifact>()
                .HasMany(e => e.Views)
                .WithRequired(e => e.Artifact)
                .HasForeignKey(e => e.ARTIFACT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.SalaryRates)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CATEGORY_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.SubCategories)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CATEGORY_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Episode>()
                .HasMany(e => e.Feedbacks)
                .WithOptional(e => e.Episode)
                .HasForeignKey(e => e.EPISODE_FID);

            modelBuilder.Entity<Episode>()
                .HasMany(e => e.Views)
                .WithRequired(e => e.Episode)
                .HasForeignKey(e => e.EPISODE_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Feedback>()
                .HasMany(e => e.Feedback1)
                .WithOptional(e => e.Feedback2)
                .HasForeignKey(e => e.FEEDBACK_FID);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Order_Details)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.ORDER_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Premium>()
                .HasMany(e => e.ReaderPremiums)
                .WithRequired(e => e.Premium)
                .HasForeignKey(e => e.PREMIUM_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reader>()
                .Property(e => e.READER_NAME)
                .IsFixedLength();

            modelBuilder.Entity<Reader>()
                .Property(e => e.READER_EMAIL)
                .IsFixedLength();

            modelBuilder.Entity<Reader>()
                .Property(e => e.READER_PASSWORD)
                .IsFixedLength();

            modelBuilder.Entity<Reader>()
                .HasMany(e => e.Bookmarks)
                .WithRequired(e => e.Reader)
                .HasForeignKey(e => e.READER_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reader>()
                .HasMany(e => e.Feedbacks)
                .WithRequired(e => e.Reader)
                .HasForeignKey(e => e.READER_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reader>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Reader)
                .HasForeignKey(e => e.READER_FID);

            modelBuilder.Entity<Reader>()
                .HasMany(e => e.ReaderPremiums)
                .WithRequired(e => e.Reader)
                .HasForeignKey(e => e.READER_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reader>()
                .HasMany(e => e.Views)
                .WithRequired(e => e.Reader)
                .HasForeignKey(e => e.READER_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Schedule>()
                .HasMany(e => e.Artifacts)
                .WithOptional(e => e.Schedule)
                .HasForeignKey(e => e.SCHEDULE_FID);

            modelBuilder.Entity<ShopArtifact>()
                .HasMany(e => e.Order_Details)
                .WithRequired(e => e.ShopArtifact)
                .HasForeignKey(e => e.SHOPARTIFACT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Artifacts)
                .WithRequired(e => e.SubCategory)
                .HasForeignKey(e => e.SUB_CATEGORY_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Writer>()
                .HasMany(e => e.Artifacts)
                .WithRequired(e => e.Writer)
                .HasForeignKey(e => e.WRITER_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Writer>()
                .HasMany(e => e.Notificatons)
                .WithRequired(e => e.Writer)
                .HasForeignKey(e => e.WRITER_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Writer>()
                .HasMany(e => e.Withdraw_Amount)
                .WithRequired(e => e.Writer)
                .HasForeignKey(e => e.WRITER_FID)
                .WillCascadeOnDelete(false);
        }
    }
}
