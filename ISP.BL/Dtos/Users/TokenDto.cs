using System.Security.Claims;

namespace ISP.BL.Dtos.Users;
public class TokenDto
{
    public TokenDto(string Token, DateTime ExpireDate  )
    {
        this.Token = Token;
        this.ExpireDate = ExpireDate;
        //this.UserClaims = userClaims;
        
    }
    public string Token { get; set; }  
    public DateTime ExpireDate { get; set; }

    // public List<Claim> UserClaims { get; set; }
}
