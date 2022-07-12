using System.ComponentModel.DataAnnotations;

namespace ControleMedicamentos.src.dtos
{
    /// <summary>
    /// <para>Resumo: Classe espelho para criar um novo medicamento</para>
    /// <para>Criado por: Kauane Farias</para>
    /// <para>Versão 1.0</para>
    /// <para>Data: 12/07/2022</para>
    /// </summary>
    public class MedicamentoDTO
    {
        [Required, StringLength(50)]
        public string Nome { get; set; }

        public MedicamentoDTO(string nome)
        {
            Nome = nome;
        }
    }
}
