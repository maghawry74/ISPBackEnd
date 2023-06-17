namespace ISP.BL.Dtos.Users;
public class TokenDto
{
    public TokenDto(string Token, DateTime ExpireDate , List<ClaimDto> userClaims, List<string> roleClaims)
    {
        this.Token = Token;
        this.ExpireDate = ExpireDate;
        this.UserClaims = userClaims;
        this.RoleClaims = roleClaims;
    }
    public string Token { get; set; }
    public List<ClaimDto> UserClaims { get; set; }
    public List<string> RoleClaims { get; set; }
    public DateTime ExpireDate { get; set; }
}
