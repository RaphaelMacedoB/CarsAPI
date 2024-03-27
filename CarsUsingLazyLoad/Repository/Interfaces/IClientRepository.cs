using CarsUsingLazyLoad.Data.Dtos;
using CarsUsingLazyLoad.Data.Models;

namespace CarsUsingLazyLoad.Repository.Interfaces
{
  public interface IClientRepository : IBaseRepository
  {
    Task<List<Client>> GetAll();
    Task<Client> GetById(int id);

    Task<SaleDto> GetSaleByClientId(int id);
  }
}
