using System.ComponentModel.DataAnnotations;

namespace ISP.BL
{
    public class UpdateClientDTO
    {

        [Required(ErrorMessage = "the client ssn must not be empty")]
        [MaxLength(14)]
        public int SSn { get; set; }
        [Required]
        public int PackageId { get; set; }
    }
}
