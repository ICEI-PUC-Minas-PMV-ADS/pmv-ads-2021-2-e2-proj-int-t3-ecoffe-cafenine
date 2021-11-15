using Ecoffe.Backend.Models;
using System.Threading.Tasks;

namespace Ecoffe.Backend.Interfaces
{
    public interface IEnderecoService
    {
        Task<Endereco> Save(Endereco endereco);
    }
}
