
namespace ISP.BL.Dtos.Offer;
public class ReadOfferDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double CancelFine { get; set; }
    public double FineOfSuspensed { get; set; }
    public bool IsPossibleToRasieOrLower { get; set; }
    public int NumOfOfferMonth { get; set; }
    public int NumOfFreeMonth { get; set; }
    public bool Isfreefirst { get; set; }
    public bool IsPercentageDiscount { get; set; }
    public double DiscoutAmout { get; set; }
    public bool HasRouter { get; set; }
    public double RouterPrice { get; set; }
    public bool Status { get; set; } 
    public int providerId { get; set; }
}
