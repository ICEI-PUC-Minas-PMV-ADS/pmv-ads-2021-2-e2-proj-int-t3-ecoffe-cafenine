using Ecoffe.Backend.Models;
using System.Threading.Tasks;

namespace Ecoffe.Backend.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> Save(Usuario usuario);
    }
}
