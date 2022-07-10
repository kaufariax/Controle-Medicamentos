﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ControleMedicamentos.src.modelos
{
    [Table("tb_pacientes")]
    public class Paciente
    {
        #region Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Nome { get; set; }

        [JsonIgnore, InverseProperty("Paciente")]
        public List<ControleDados> MedicamentosTomados { get; set; }

        #endregion
    }
}
