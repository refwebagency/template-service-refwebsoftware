using Microsoft.EntityFrameworkCore;
using TemplateService.Models;

namespace TemplateService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Template> Template { get; set; }
    }
}