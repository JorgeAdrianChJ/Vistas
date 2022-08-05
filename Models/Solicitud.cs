using System;
using System.Collections.Generic;

namespace Registro_Efectos_Adversos.Models
{
    public partial class Solicitud
    {
        public int Id { get; set; }
        public int? IdMedico { get; set; }
        public int? IdClinica { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdVacuna { get; set; }
        public bool Respuesta1 { get; set; } = false; 
        public bool Respuesta2 { get; set; } = false; 
        public bool Respuesta3 { get; set; } = false;
        public bool Respuesta4 { get; set; } = false;
        public bool Respuesta5 { get; set; } = false; 
        public bool Respuesta6 { get; set; } = false; 
        public bool Respuesta7 { get; set; } = false;
        public bool Respuesta8 { get; set; } = false;
        public bool Respuesta9 { get; set; } = false;
        public bool Respuesta10 { get; set; } = false;
        public string? Respuesta11 { get; set; }
        public bool Respuesta12 { get; set; } = false;
        public bool Respuesta13 { get; set; } = false;
        public bool Respuesta14 { get; set; } = false;
        public bool Respuesta15 { get; set; } = false;
        public bool Respuesta16 { get; set; } = false;
        public string? Respuesta17 { get; set; }
        public bool Respuesta18 { get; set; } = false;
        public bool Respuesta19 { get; set; } = false;
        public bool Respuesta21 { get; set; } = false;
        public bool Respuesta22 { get; set; } = false;
        public bool Respuesta23 { get; set; } = false;
        public bool Respuesta24 { get; set; } = false;
        public bool Respuesta25 { get; set; } = false;
        public bool Respuesta26 { get; set; } = false;
        public bool Respuesta27 { get; set; } = false;
        public bool Respuesta28 { get; set; } = false;
        public bool Respuesta29 { get; set; } = false;
        public bool Respuesta30 { get; set; } = false;
        public bool Respuesta31 { get; set; } = false;
        public bool Respuesta32 { get; set; } = false;
        public bool Respuesta33 { get; set; } = false;
        public bool Respuesta34 { get; set; } = false;
        public bool Respuesta35 { get; set; } = false;
        public bool Respuesta36 { get; set; } = false;
        public bool Respuesta37 { get; set; } = false;
        public bool Respuesta38 { get; set; } = false;
        public bool Respuesta39 { get; set; } = false;
        public bool Respuesta40 { get; set; } = false;
        public bool Respuesta41 { get; set; } = false;
        public bool Respuesta42 { get; set; } = false;
        public bool Respuesta43 { get; set; } = false;
        public bool Respuesta44 { get; set; } = false;
        public bool Respuesta45 { get; set; } = false;
        public bool Respuesta46 { get; set; } = false;
        public bool Respuesta47 { get; set; } = false;
        public bool Respuesta48 { get; set; } = false;
        public bool Respuesta49 { get; set; } = false;
        public bool Respuesta50 { get; set; } = false;
        public bool Respuesta51 { get; set; } = false;
        public bool Respuesta52 { get; set; } = false;
        public bool Respuesta53 { get; set; } = false;
        public bool Respuesta54 { get; set; } = false;
        public bool Respuesta55 { get; set; } = false;
        public bool Respuesta56 { get; set; } = false;
        public bool Respuesta57 { get; set; } = false;
        public bool Respuesta58 { get; set; } = false;
        public bool Respuesta59 { get; set; } = false;
        public bool Respuesta60 { get; set; } = false;
        public bool Respuesta61 { get; set; } = false;
        public bool Respuesta62 { get; set; } = false;
        public bool Respuesta63 { get; set; } = false;
        public bool Respuesta64 { get; set; } = false;
        public string? Respuesta65 { get; set; }
        public string? Respuesta66 { get; set; } 
        public bool Respuesta67 { get; set; } = false;
        public bool Respuesta68 { get; set; } = false;
        public bool Respuesta69 { get; set; } = false;
        public bool Respuesta70 { get; set; } = false;
        public bool Respuesta71 { get; set; } = false;
        public bool Respuesta72 { get; set; } = false;
        public bool Respuesta73 { get; set; } = false;
        public bool Respuesta74 { get; set; } = false;
        public bool Respuesta75 { get; set; } = false;
        public bool Respuesta76 { get; set; } = false;
        public bool Respuesta77 { get; set; } = false;
        public bool Respuesta78 { get; set; } = false;
        public bool Respuesta79 { get; set; } = false;
        public bool Respuesta80 { get; set; } = false;
        public bool Respuesta81 { get; set; } = false;
        public bool Respuesta82 { get; set; } = false;
        public bool Respuesta83 { get; set; } = false;
        public bool Respuesta84 { get; set; } = false;
        public bool Respuesta85 { get; set; } = false;
        public bool Respuesta86 { get; set; } = false;
        public bool Respuesta87 { get; set; } = false;
        public bool Respuesta88 { get; set; } = false;
        public bool Respuesta89 { get; set; } = false;

        public virtual Clinica? IdClinicaNavigation { get; set; }
        public virtual Medico? IdMedicoNavigation { get; set; }
        public virtual Paciente? IdPacienteNavigation { get; set; }
        public virtual Vacuna? IdVacunaNavigation { get; set; }
    }
}
