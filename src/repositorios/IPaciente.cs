﻿using ControleMedicamentos.src.dtos;
using ControleMedicamentos.src.modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleMedicamentos.src.repositorios
{
    public interface IPaciente
    {
        Task NovoPacienteAsync(PacienteDTO paciente);
        Task<List<Paciente>> PegarTodosPacientesAsync();
        Task<List<ControleDados>> PegarMedicamentosTomadosAsync(string nome);
    }
}
