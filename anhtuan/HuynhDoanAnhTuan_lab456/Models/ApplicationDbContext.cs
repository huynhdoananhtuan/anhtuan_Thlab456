using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace NguyenDuyNam_lab456.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Courses> Course { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Following> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }
        public object Courses { get; internal set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Following>()
                .HasRequired(a => a.Courses)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
               .HasMany(u => u.Followers)
               .WithRequired(f => f.Follwee)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
               .HasMany(u => u.Followees)
               .WithRequired(f => f.Follower)
               .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);

        }
    }
}