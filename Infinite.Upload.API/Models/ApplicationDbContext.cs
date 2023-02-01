using Microsoft.EntityFrameworkCore;

namespace Infinite.Upload.API.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<UploadImage> Uploads { get; set; }
    }
}
