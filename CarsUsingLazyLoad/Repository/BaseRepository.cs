using CarsUsingLazyLoad.Data.Context;
using CarsUsingLazyLoad.Repository.Interfaces;

namespace CarsUsingLazyLoad.Repository
{
  public class BaseRepository(MySqlContext context) : IBaseRepository
  {
    private readonly MySqlContext _context = context;

    public void Add<T>(T entity) where T : class
    {
      _context.Add(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
      _context.Remove(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }

    public void Update<T>(T entity) where T : class
    {
      _context.Update(entity);
    }
  }
}
