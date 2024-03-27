using CarsUsingLazyLoad.Data.Context;
using CarsUsingLazyLoad.Data.Models;
using CarsUsingLazyLoad.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarsUsingLazyLoad.Repository
{
  public class SellerRepository : BaseRepository, ISellerRepository
  {
    private readonly MySqlContext _context;
    public SellerRepository(MySqlContext context) : base(context)
    {
      _context = context;
    }

    public async Task<List<Seller>> GetAll()
    {
      return await _context.Sellers.ToListAsync();
    }

    public async Task<Seller> GetById(int id)
    {
      return await _context.Sellers.FirstOrDefaultAsync(x => x.Id == id);
    }
  }
}
