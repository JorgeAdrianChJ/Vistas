using System;
using System.Collections.Generic;

namespace Registro_Efectos_Adversos.Models
{
    public partial class Clinica
    {
        public Clinica()
        {
            Solicituds = new HashSet<Solicitud>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? CedulaJurica { get; set; }
        public string? Pais { get; set; }
        public string? Provincia { get; set; }
        public string? Distrito { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Web { get; set; }

        public virtual ICollection<Solicitud> Solicituds { get; set; }
    }
}
