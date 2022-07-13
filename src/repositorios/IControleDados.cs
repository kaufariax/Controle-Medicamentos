using ControleMedicamentos.src.dtos;
using System.Threading.Tasks;

namespace ControleMedicamentos.src.repositorios
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar método de criação do controle de dados</para>
    /// <para>Criado por: Kauane Farias</para>
    /// <para>Versão 1.0</para>
    /// <para>Data: 12/07/2022</para>
    /// </summary>
    public interface IControleDados
    {
        Task NovoRegistroDadosAsync(ControleDadosDTO controleDados);
    }
}
