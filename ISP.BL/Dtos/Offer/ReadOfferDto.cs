
namespace ISP.BL.Dtos.Offer;
public class ReadOfferDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ReadProviderDTO? Provider { get; set; }
    public double DiscoutAmout { get; set; }
    public bool IsPercentageDiscount { get; set; }
    public double CancelFine { get; set; }
    public int NumOfFreeMonth { get; set; }
    public int NumOfOfferMonth { get; set; }  
    public bool Isfreefirst { get; set; }
    public bool HasRouter { get; set; }
    public double RouterPrice { get; set; }
   
}
