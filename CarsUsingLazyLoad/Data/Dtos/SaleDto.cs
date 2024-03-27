using CarsUsingLazyLoad.Data.Models;

namespace CarsUsingLazyLoad.Data.Dtos
{
  public class SaleDto
  {
    public int Id { get; set; }
    public DateTime Dateofsale { get; set; }
    public virtual Car? Car { get; set; }
    public virtual Client? Client { get; set; }
    public virtual Seller? Seller { get; set; }
  }
}
