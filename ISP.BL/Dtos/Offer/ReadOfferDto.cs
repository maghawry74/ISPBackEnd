
namespace ISP.BL.Dtos.Offer;
public class ReadOfferDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ReadProviderDTO? Provider { get; set; }
    public float Discount { get; set; }
    public bool IsPercent { get; set; }
    public float CancelFee { get; set; }
    public int NumberOfFreeMonths { get; set; }
    public int NumberOfMonths { get; set; }
    public bool FreeMonthsFirst { get; set; }
    public bool FreeRouter { get; set; }
   // public double SuspendFee { get; set; }
    public float RouterPrice { get; set; }

}
