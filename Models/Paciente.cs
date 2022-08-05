using System;
using System.Collections.Generic;

namespace Registro_Efectos_Adversos.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Solicituds = new HashSet<Solicitud>();
            Vacunas = new HashSet<Vacuna>();
        }

        public int Id { get; set; }
        public string? Identificacion { get; set; }
        public string? Nombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Sexo { get; set; }
        public string? NumeroContacto { get; set; }
        public string? Pais { get; set; }
        public string? Provincia { get; set; }
        public string? Distrito { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? Ocupacion { get; set; }

        public virtual ICollection<Solicitud> Solicituds { get; set; }
        public virtual ICollection<Vacuna> Vacunas { get; set; }
    }
}
