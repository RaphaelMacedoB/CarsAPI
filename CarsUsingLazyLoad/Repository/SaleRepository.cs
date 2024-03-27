using CarsUsingLazyLoad.Data.Context;
using CarsUsingLazyLoad.Data.Dtos;
using CarsUsingLazyLoad.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarsUsingLazyLoad.Repository
{
  public class SaleRepository : BaseRepository, ISaleRepository
  {
    private readonly MySqlContext _context;
    public SaleRepository(MySqlContext context) : base(context)
    {
      _context = context;
    }

    public async Task<List<SaleDto>> GetAll()
    {
      return await _context.Sales
        .Select(x => new SaleDto { Id = x.Id, Dateofsale = x.Dateofsale, Car = x.Car, Client = x.Client, Seller = x.Seller })
        .ToListAsync();
    }
    public async Task<SaleDto> GetById(int id)
    {
      return await _context
        .Sales
        .Select(x => new SaleDto { Id = x.Id, Dateofsale = x.Dateofsale, Car = x.Car, Client = x.Client, Seller = x.Seller })
        .Where(x => x.Id == id)
        .FirstOrDefaultAsync();
    }
    //public async Task<Car> GetCarByCarId(int carId)
    //{
    //  return await _context.Cars.Where(x => x.Id == carId)
    //    .FirstOrDefaultAsync();
    //}
  }
}
