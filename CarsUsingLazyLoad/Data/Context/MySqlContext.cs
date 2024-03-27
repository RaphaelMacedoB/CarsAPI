using CarsUsingLazyLoad.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsUsingLazyLoad.Data.Context
{
  public class MySqlContext(DbContextOptions<MySqlContext> options) : DbContext(options)
  {
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Seller> Sellers { get; set; }
  }
}
