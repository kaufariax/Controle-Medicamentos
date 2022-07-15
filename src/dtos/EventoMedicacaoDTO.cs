namespace ControleMedicamentos.src.dtos
{
    /// <summary>
    /// <para>Resumo: Classe espelho para criar um novo evento de medicação</para>
    /// <para>Criado por: Kauane Farias</para>
    /// <para>Versão 1.0</para>
    /// <para>Data: 12/07/2022</para>
    /// </summary>
    public class EventoMedicacaoDTO
    { 
        public PacienteDTO Paciente { get; set; }
        public MedicamentoDTO Medicamento { get; set; }

        public EventoMedicacaoDTO(PacienteDTO paciente, MedicamentoDTO medicamento)
        {
            Paciente = paciente;
            Medicamento = medicamento;
        }
    }
}
