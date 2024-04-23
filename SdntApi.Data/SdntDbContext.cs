using Microsoft.EntityFrameworkCore;
using SdntApi.Models.Domains;


namespace SdntApi.Data
{
	public class SdntDbContext : DbContext
	{
        public SdntDbContext(DbContextOptions<SdntDbContext> dbContextOptions) : base(dbContextOptions)
        { 
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Marksheet> Marksheets { get; set; }
    }
}
