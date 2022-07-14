using ControleMedicamentos.src.dtos;
using ControleMedicamentos.src.modelos;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleMedicamentos.src.repositorios
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar método de criação e consultas do medicamento</para>
    /// <para>Criado por: Kauane Farias</para>
    /// <para>Versão 1.0</para>
    /// <para>Data: 10/07/2022</para>
    /// </summary>
    public interface IMedicamento
    {
        Task NovoMedicamentoAsync(MedicamentoDTO medicamento);
        Task<List<Medicamento>> PegarTodosMedicamentosAsync();
        Task<List<ControleDados>> PegarControlePacientesAsync(string nome);
        IEnumerable PegarQuantidadePacientesTomaram();
    }
}
