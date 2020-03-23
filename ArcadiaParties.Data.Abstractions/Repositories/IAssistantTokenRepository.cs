using System.Threading.Tasks;

namespace ArcadiaParties.Data.Abstractions.Repositories
{
    public interface IAssistantTokenRepository
    {
        Task<string> GetToken();
    }
}
