using System.Threading.Tasks;
using LocalMindApi.Models.LocalAIs;

namespace LocalMindApi.Repositories.LocalAIs
{
    public interface ILocalAIApiRepository
    {
        ValueTask<LocalAIResponse> PostLocalAIRequestAsync(LocalAIRequest localAIRequest);
    }
}
