using Microsoft.EntityFrameworkCore;
using TP_LW5.Models;

namespace TP_LW5.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}