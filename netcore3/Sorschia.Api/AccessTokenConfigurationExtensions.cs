using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Sorschia
{
    public static class AccessTokenConfigurationExtensions
    {
        public static SymmetricSecurityKey GetIssuerSigningKey(this AccessTokenConfiguration instance)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(instance.Secret));
        }
    }
}
