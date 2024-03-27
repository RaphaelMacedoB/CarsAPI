using CarsUsingLazyLoad.Data.Dtos;

namespace CarsUsingLazyLoad.Repository.Interfaces
{
  public interface ISaleRepository : IBaseRepository
  {
    Task<List<SaleDto>> GetAll();
    Task<SaleDto> GetById(int id);
    //Task<Car> GetCarByCarId(int carId);
  }
}
