using System.Threading.Tasks;

namespace ArcadiaParties.Data.Abstractions.Repositories
{
    public interface ITokenForAssistantRepository
    {
        Task<string> GetToken();
    }
}
