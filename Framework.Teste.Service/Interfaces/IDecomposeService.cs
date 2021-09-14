using System.Threading.Tasks;
using Framework.Teste.Entities.Dtos;

namespace Framework.Teste.Service.Interfaces
{
    public interface IDecomposeService
    {
        Task<DecomposeNumbers> DecomposeAsync(int input);
    }
}