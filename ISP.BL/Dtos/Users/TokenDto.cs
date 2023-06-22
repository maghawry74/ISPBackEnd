using System.Security.Claims;

namespace ISP.BL.Dtos.Users;
public class TokenDto
{
    public TokenDto(string Token, DateTime ExpireDate ,List<string> permissions)
    {
        this.Token = Token;
        this.ExpireDate = ExpireDate;
        this.Permissions = permissions;
        
    }
    public string Token { get; set; }  
    public DateTime ExpireDate { get; set; }
     public List<string> Permissions { get; set; }
}
