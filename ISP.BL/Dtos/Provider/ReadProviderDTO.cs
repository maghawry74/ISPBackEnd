
namespace ISP.BL
{
   public class ReadProviderDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required bool IsActive { get; set; } 
    }
}
