using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Registro_Efectos_Adversos.Models;

namespace Vistas.Data
{
    public class VistasContext : DbContext
    {
        public VistasContext (DbContextOptions<VistasContext> options)
            : base(options)
        {
        }

        public DbSet<Registro_Efectos_Adversos.Models.Medico> Medico { get; set; } = default!;

        public DbSet<Registro_Efectos_Adversos.Models.Clinica>? Clinica { get; set; }

        public DbSet<Registro_Efectos_Adversos.Models.Paciente>? Paciente { get; set; }

        public DbSet<Registro_Efectos_Adversos.Models.Vacuna>? Vacuna { get; set; }

        public DbSet<Registro_Efectos_Adversos.Models.Solicitud>? Solicitud { get; set; }
    }
}
