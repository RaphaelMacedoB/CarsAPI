using CarsUsingLazyLoad.Data.Models;

namespace CarsUsingLazyLoad.Repository.Interfaces
{
  public interface ISellerRepository : IBaseRepository
  {
    Task<List<Seller>> GetAll();
    Task<Seller> GetById(int id);
  }
}
