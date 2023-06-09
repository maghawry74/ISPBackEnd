using System.ComponentModel.DataAnnotations;
namespace ISP.BL
{
    public class WriteBranchDTO
    {
        public required string Name { get; set; } = string.Empty;

        public required string address { get; set; } = string.Empty;

        public string phone1 { get; set; } = string.Empty;

        public string phone2 { get; set; } = string.Empty;
        [RegularExpression(@"^01[012][0-9]{11}$")]
        public string mobile1 { get; set; } = string.Empty;
        [RegularExpression(@"^01[012][0-9]{11}$")]
        public string mobile2 { get; set; } = string.Empty;


       // public required ICollection<WritePhoneDto> Phones { get; set; } = new HashSet<WritePhoneDto>();
       // public required ICollection<WriteMobileDto> Mobiles { get; set; } = new HashSet<WriteMobileDto>();
        public int? Fax { get; set; }
        public required string ManagerId { get; set; } = string.Empty;
        public int GovernarateCode { get; set; }
    }
}
