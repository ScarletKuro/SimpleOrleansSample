using System.Threading.Tasks;
using Orleans;
using Orleans.CodeGeneration;

namespace SimpleOrleansSample.Interfaces
{
    [Version(1)]
    public interface IDemoGrain : IGrainWithStringKey
    {
        Task<int> GetRandomNumber();
    }
}
