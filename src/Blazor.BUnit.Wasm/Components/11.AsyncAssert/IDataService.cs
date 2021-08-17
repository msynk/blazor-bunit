using System.Threading.Tasks;

namespace Blazor.BUnit.Wasm
{
    public interface IDataService
    {
        Task<string> Get(int id);
    }
}
