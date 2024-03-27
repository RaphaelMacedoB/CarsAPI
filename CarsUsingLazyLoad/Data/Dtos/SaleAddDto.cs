namespace CarsUsingLazyLoad.Data.Dtos
{
  public class SaleAddDto
  {
    public DateTime Dateofsale { get; set; }
    public int CarId { get; set; }
    public int ClientId { get; set; }
    public int SellerId { get; set; }
  }
}
