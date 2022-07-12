
namespace ControleMedicamentos.src.dtos
{
    /// <summary>
    /// <para>Resumo: Classe espelho para criar um novo controle de dados</para>
    /// <para>Criado por: Kauane Farias</para>
    /// <para>Versão 1.0</para>
    /// <para>Data: 12/07/2022</para>
    /// </summary>
    public class ControleDadosDTO
    { 
        public PacienteDTO Paciente { get; set; }
        public MedicamentoDTO Medicamento { get; set; }

        public ControleDadosDTO(PacienteDTO paciente, MedicamentoDTO medicamento)
        {
            Paciente = paciente;
            Medicamento = medicamento;
        }
    }
}
