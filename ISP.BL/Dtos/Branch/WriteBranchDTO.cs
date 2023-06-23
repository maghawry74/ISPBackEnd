using System.ComponentModel.DataAnnotations;
namespace ISP.BL
{
    public class WriteBranchDTO
    {
        [StringLength(50 , ErrorMessage ="Name must not exceeds 50 characters")]
        public required string Name { get; set; } = string.Empty;




        public string tel1 { get; set; } = string.Empty;
  
        public string tel2 { get; set; } = string.Empty;

        [RegularExpression(@"^01[012][0-9]{11}$")]
        public string phone1 { get; set; } = string.Empty;

        [RegularExpression(@"^01[012][0-9]{11}$")]
        public string phone2 { get; set; } = string.Empty;

       

        public int? Fax { get; set; }

        public  string ManagerId { get; set; } = string.Empty;


        public int GovernarateCode { get; set; }
    }
}
