using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ControleMedicamentos.src.modelos
{
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
        public List<ControleDados> ControlePacientes { get; set; }

        #endregion
    }
}
