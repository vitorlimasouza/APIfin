using Microsoft.EntityFrameworkCore;
using APIfin.Models;

namespace APIfin.Data;

public class DbRepository : DbContext
{
    public DbRepository(DbContextOptions options) : base(options){

    }

    public DbSet<Period> Periods { get; set; }
    public DbSet<Movement> Movements { get; set; }
}