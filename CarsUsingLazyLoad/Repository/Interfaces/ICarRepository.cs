using CarsUsingLazyLoad.Data.Dtos;
using CarsUsingLazyLoad.Data.Models;

namespace CarsUsingLazyLoad.Repository.Interfaces
{
  public interface ICarRepository : IBaseRepository
  {
    Task<IEnumerable<CarDto>> GetAll();
    Task<Car> GetById(int id);
  }
}
