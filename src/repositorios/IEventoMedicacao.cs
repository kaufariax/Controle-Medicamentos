using ControleMedicamentos.src.dtos;
using System.Threading.Tasks;

namespace ControleMedicamentos.src.repositorios
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar método de criação do evento de medicação</para>
    /// <para>Criado por: Kauane Farias</para>
    /// <para>Versão 1.1</para>
    /// <para>Data: 10/07/2022</para>
    /// </summary>
    public interface IEventoMedicacao
    {
        Task NovoRegistroMedicacaoAsync(EventoMedicacaoDTO eventoMedicacao);
    }
}
