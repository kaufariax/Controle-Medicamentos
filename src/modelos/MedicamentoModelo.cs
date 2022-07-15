using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ControleMedicamentos.src.modelos
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por representar tb_medicamentos no banco.</para>
    /// <para>Criado por: Kauane Farias</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 09/07/2022</para>
    /// </summary>
    [Table("tb_medicamentos")]
    public class Medicamento
    {
        #region Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Nome { get; set; }

        [JsonIgnore, InverseProperty("Medicamento")]
        public List<EventoMedicacao> ControlePacientes { get; set; }

        #endregion
    }
}
