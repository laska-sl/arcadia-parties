using System.Threading.Tasks;

namespace ArcadiaParties.API.Token
{
    public interface ITokenService
    {
        Task<string> GetTokenAsync();
    }
}