using CarsUsingLazyLoad.Data.Context;
using CarsUsingLazyLoad.Data.Dtos;
using CarsUsingLazyLoad.Data.Models;
using CarsUsingLazyLoad.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarsUsingLazyLoad.Repository
{
  public class ClientRepository : BaseRepository, IClientRepository
  {
    private readonly MySqlContext _context;
    public ClientRepository(MySqlContext context) : base(context)
    {
      _context = context;
    }

    public async Task<List<Client>> GetAll()
    {
      return await _context.Clients.ToListAsync();
    }

    public async Task<Client> GetById(int id)
    {
      return await _context.Clients.SingleOrDefaultAsync(x => x.Id == id);
    }
    public async Task<SaleDto> GetSaleByClientId(int id)
    {
      return await _context.Sales.
        Where(x => x.ClientId == id)
        .Select(x =>
        new SaleDto { Id = x.Id, Car = x.Car, Client = x.Client, Dateofsale = x.Dateofsale, Seller = x.Seller })
        .FirstOrDefaultAsync();
    }
  }
}
