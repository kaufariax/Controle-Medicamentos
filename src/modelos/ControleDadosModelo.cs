using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleMedicamentos.src.modelos
{
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

        [Required]
        public int QuantidadeMedicamento { get; set; }

        #endregion
    }
}
