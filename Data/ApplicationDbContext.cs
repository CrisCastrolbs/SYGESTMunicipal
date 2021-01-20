using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SYGESTMunicipal.Areas.Admin.Models;
using SYGESTMunicipal.Areas.OFGA.Models;
using SYGESTMunicipal.Areas.OFIM.Models;
using SYGESTMunicipal.Areas.PATENTES.Models;

namespace SYGESTMunicipal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EstadoCivil> EstadoCivil { get; set; }
        public DbSet<Nacionalidad> Nacionalidad { get; set; }
        public DbSet<NivelAcademico> NivelAcademico { get; set; }
        public DbSet<Ocupacion> Ocupacion { get; set; }
        public DbSet<Seguro> Seguro { get; set; }
        public DbSet<TipoConsulta> TipoConsulta { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Seguimiento> Seguimiento { get; set; }
        public DbSet<PersonaOFIM> PersonaOFIM { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Eje> Eje { get; set; }
        public DbSet<Actividad> Actividad { get; set; }
        public DbSet<Cupos> Cupos { get; set; }
        public DbSet<ActivityType> ActivityType { get; set; }
        public DbSet<Applicant> Applicant { get; set; }
        public DbSet<CIIU> CIIU { get; set; }
        public DbSet<EstablishmentType> EstablishmentType { get; set; }
        public DbSet<Establishment> Establishment { get; set; }
        public DbSet<PersonPatentes> PersonPatentes { get; set; }
        public DbSet<RequestReason> RequestReason { get; set; }
        public DbSet<Talks> Talks { get; set; }
        public DbSet<MaterialType> MaterialType { get; set; }
        public DbSet<Materials> Materials { get; set; }
        public DbSet<SolidWaste> SolidWaste { get; set; }
        public DbSet<PersonOFGA> PersonOFGA { get; set; }
        public DbSet<Complaint> Complaint { get; set; }
        public DbSet<RecoverableMaterialRecovery> RecoverableMaterialRecovery { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        




    }
}
