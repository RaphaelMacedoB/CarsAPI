using System.ComponentModel.DataAnnotations.Schema;

namespace CarsUsingLazyLoad.Data.Models
{
  public class Sale : Base
  {
    public DateTime Dateofsale { get; set; }

    [ForeignKey("Car")]
    public int CarId { get; set; }
    public virtual Car Car { get; set; }

    [ForeignKey("Client")]
    public int ClientId { get; set; }
    public virtual Client Client { get; set; }

    [ForeignKey("Seller")]
    public int SellerId { get; set; }
    public virtual Seller Seller { get; set; }
  }
}
