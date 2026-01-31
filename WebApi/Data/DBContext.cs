using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using WebBlog.Models.Domain;

namespace WebApi.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<BlogpostTag> BlogPostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define the Composite Key
            modelBuilder.Entity<BlogpostTag>()
                .HasKey(bt => new { bt.BlogpostId, bt.TagId });

            // (Optional) Explicitly define the relationships
            modelBuilder.Entity<BlogpostTag>()
                .HasOne(bt => bt.Blogpost)
                .WithMany(b => b.BlogpostTags)
                .HasForeignKey(bt => bt.BlogpostId);

            modelBuilder.Entity<BlogpostTag>()
                .HasOne(bt => bt.Tag)
                .WithMany(t => t.BlogpostTags)
                .HasForeignKey(bt => bt.TagId);
        }
    }
}
