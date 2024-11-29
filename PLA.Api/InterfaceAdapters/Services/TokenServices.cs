namespace PLA.Api.InterfaceAdapters.Services;

public class TokenServices : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly int _expiresMinute;
    private readonly string _validAudience;

    public TokenServices(IConfiguration configuration)
    {
        _configuration = configuration;
        _expiresMinute = _configuration.GetValue<int>("JWT:ExpiresMinute");
        _validAudience = _configuration["JWT:ValidAudience"];
    }

    public ValueTask<string> CreateToken(UsuarioDTO usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Convert.FromBase64String(_configuration["JWT:Key"]);
        var claims = GetClaims(usuario);
        var tokenDescription = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Expires = DateTime.UtcNow.AddMinutes(_expiresMinute),
            Audience = _validAudience
        };
        SecurityToken token = tokenHandler.CreateToken(tokenDescription);
        return ValueTask.FromResult(tokenHandler.WriteToken(token));
    }

    private List<Claim> GetClaims(UsuarioDTO usuario)
    {
        return
        [
            new("userId", Crypto.EncryptStringAES(usuario.Id.ToString())),
            new("firstName", usuario.Nombre)
        ];
    }
}
