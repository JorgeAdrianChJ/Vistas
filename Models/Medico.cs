using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Registro_Efectos_Adversos.Models
{
    public partial class Medico
    {
        public Medico()
        {
            Solicituds = new HashSet<Solicitud>();
        }
        [Required]
        public string? Identificacion { get; set; }
        [Required]
        public string? CodigoProfesional { get; set; }
        [Required]
        public string? NombreCompleto { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string? Correo { get; set; }
        [Required]
        public string? Pais { get; set; }
        [Required]
        public string? Estado { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Solicitud> Solicituds { get; set; }
    }
}
