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
    }
}
