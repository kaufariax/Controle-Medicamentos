using ControleMedicamentos.src.dtos;
using ControleMedicamentos.src.modelos;
using System.Threading.Tasks;

namespace ControleMedicamentos.src.repositorios
{
    public interface IControleDados
    {
        Task NovoRegistroDadosAsync(ControleDadosDTO controleDados);
    }
}
