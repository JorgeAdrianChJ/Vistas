using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Registro_Efectos_Adversos.Models
{
    public partial class registro_efectos_adversosContext : DbContext
    {
        public registro_efectos_adversosContext()
        {
        }

        public registro_efectos_adversosContext(DbContextOptions<registro_efectos_adversosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinicas { get; set; } = null!;
        public virtual DbSet<Medico> Medicos { get; set; } = null!;
        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;
        public virtual DbSet<Solicitud> Solicituds { get; set; } = null!;
        public virtual DbSet<Vacuna> Vacunas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=registro_efectos_adversos;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.ToTable("clinica");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CedulaJurica)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cedula_jurica");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Distrito)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("distrito");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Pais)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pais");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("provincia");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.Web)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("web");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.ToTable("medico");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodigoProfesional)
                    .HasMaxLength(50)
                    .HasColumnName("codigo_profesional");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .HasColumnName("correo");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .HasColumnName("estado");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(50)
                    .HasColumnName("identificacion");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(100)
                    .HasColumnName("nombre_completo");

                entity.Property(e => e.Pais)
                    .HasMaxLength(50)
                    .HasColumnName("pais");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.ToTable("paciente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Distrito)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("distrito");

                entity.Property(e => e.EstadoCivil)
                    .HasMaxLength(1)
                    .HasColumnName("estado_civil")
                    .IsFixedLength();

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("date")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("identificacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NumeroContacto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numero_contacto");

                entity.Property(e => e.Ocupacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ocupacion");

                entity.Property(e => e.Pais)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pais");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("primer_apellido");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("provincia");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("segundo_apellido");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .HasColumnName("sexo")
                    .IsFixedLength();

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });
            
            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.ToTable("solicitud");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdClinica).HasColumnName("id_clinica");

                entity.Property(e => e.IdMedico).HasColumnName("id_medico");

                entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Solicituds)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK_solicitud_clinica");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Solicituds)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_solicitud_medico");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Solicituds)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_solicitud_paciente");
            });

            modelBuilder.Entity<Vacuna>(entity =>
            {
                entity.ToTable("vacuna");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaAplicacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_aplicacion");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_vencimiento");

                entity.Property(e => e.Lote).HasColumnName("lote");

                entity.Property(e => e.LugarAplicacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lugar_aplicacion");

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("observaciones");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
