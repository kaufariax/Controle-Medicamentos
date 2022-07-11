using ControleMedicamentos.src.modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleMedicamentos.src.repositorios
{
    public interface IMedicamento
    {
        Task NovoMedicamentoAsync(Medicamento medicamento);
        Task<List<Medicamento>> PegarTodosMedicamentosAsync();
        Task<List<ControleDados>> PegarControlePacientesAsync(string nome);
    }
}
