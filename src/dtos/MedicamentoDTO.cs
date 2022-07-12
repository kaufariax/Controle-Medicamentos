using System.ComponentModel.DataAnnotations;

namespace ControleMedicamentos.src.dtos
{
    public class MedicamentoDTO
    {
        [Required, StringLength(50)]
        public string Nome { get; set; }
    }
}
