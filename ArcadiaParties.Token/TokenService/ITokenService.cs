using System.Threading.Tasks;

namespace ArcadiaParties.Token
{
    public interface ITokenService
    {
        Task<string> GetTokenAsync();
    }
}