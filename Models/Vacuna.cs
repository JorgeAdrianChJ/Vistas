using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Registro_Efectos_Adversos.Models
{
    public partial class Vacuna
    {
        public Vacuna()
        {
            Solicituds = new HashSet<Solicitud>();
        }

        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Marca { get; set; }
        [Required]
        public DateTime? FechaAplicacion { get; set; }
        [Required]
        public int? Lote { get; set; }
        [Required]
        public DateTime? FechaVencimiento { get; set; }
        [Required]
        public string? LugarAplicacion { get; set; }
        [Required]
        [MaxLength(250)]
        public string? Observaciones { get; set; }
        [Required]
        public string? Respuesta1 { get; set; }
        [Required]
        public string? Respuesta2 { get; set; }
        [Required]
        public string? Respuesta3 { get; set; }
        [Required]
        [MaxLength(500)]
        public string? Respuesta4 { get; set; }
        [Required]
        public string? Respuesta5 { get; set; }
        [Required]
        public string? Respuesta6 { get; set; }
        [Required]
        [MaxLength(500)]
        public string? Respuesta7 { get; set; }
        [Required]
        [MaxLength(500)]
        public string? Respuesta8 { get; set; }
        [Required]
        [MaxLength(500)]
        public string? Respuesta9 { get; set; }

        public virtual ICollection<Solicitud> Solicituds { get; set; }
    }
}
