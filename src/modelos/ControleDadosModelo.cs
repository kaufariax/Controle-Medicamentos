using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleMedicamentos.src.modelos
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por representar controle_dados no banco.</para>
    /// <para>Criado por: Kauane Farias</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 12/07/2022</para>
    /// </summary>
    [Table("controle_dados")]
    public class ControleDados
    {
        #region Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("fk_paciente")]
        public Paciente Paciente { get; set; }

        [ForeignKey("fk_medicamento")]
        public Medicamento Medicamento { get; set; }

        #endregion
    }
}
