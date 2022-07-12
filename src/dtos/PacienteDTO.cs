using System.ComponentModel.DataAnnotations;

namespace ControleMedicamentos.src.dtos
{
    public class PacienteDTO
    {
        [Required, StringLength(50)]
        public string Nome { get; set; }

        public PacienteDTO(string nome)
        {
            Nome = nome;
        }
    }
}
