
using ISP.BL.Dtos.Role;
using System.Security.Claims;

namespace ISP.BL.Dtos.Users;
public class TokenDto
{
    public TokenDto(string Token, DateTime ExpireDate , List<ClaimDto> claims)
    {
        this.Token = Token;
        this.ExpireDate = ExpireDate;
        this.Clsims = claims;
    }
    public string Token { get; set; }
    public List<ClaimDto> Clsims { get; set; }
    public DateTime ExpireDate { get; set; }
}
