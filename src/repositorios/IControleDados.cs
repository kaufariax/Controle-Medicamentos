using ControleMedicamentos.src.modelos;
using System.Threading.Tasks;

namespace ControleMedicamentos.src.repositorios
{
    public interface IControleDados
    {
        Task NovoRegistroDadosAsync(ControleDados controleDados);
    }
}
