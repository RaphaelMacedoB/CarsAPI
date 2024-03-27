using CarsUsingLazyLoad.Data.Context;
using CarsUsingLazyLoad.Data.Dtos;
using CarsUsingLazyLoad.Data.Models;
using CarsUsingLazyLoad.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarsUsingLazyLoad.Repository
{
  public class CarRepository : BaseRepository, ICarRepository
  {
    private readonly MySqlContext _context;
    public CarRepository(MySqlContext context) : base(context)
    {
      _context = context;
    }

    public async Task<IEnumerable<CarDto>> GetAll()
    {
      return await _context.Cars
        .Select(x => new CarDto { Id = x.Id, Model = x.Model, Amount = x.Amount })
        .ToListAsync();
    }

    public async Task<Car> GetById(int id)
    {
      return await _context.Cars
        .FirstOrDefaultAsync(x => x.Id == id);
    }
  }
}
