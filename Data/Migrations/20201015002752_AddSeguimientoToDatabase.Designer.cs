﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SYGESTMunicipal.Data;

namespace SYGESTMunicipal.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201015002752_AddSeguimientoToDatabase")]
    partial class AddSeguimientoToDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.OFIM.Models.Consulta", b =>
                {
                    b.Property<int>("ConsultaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Motivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonaOFIMId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RespuestaOfrecida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoConsultaId")
                        .HasColumnType("int");

                    b.HasKey("ConsultaId");

                    b.HasIndex("PersonaOFIMId");

                    b.HasIndex("TipoConsultaId");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.OFIM.Models.EstadoCivil", b =>
                {
                    b.Property<int>("EstadoCivilId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoCivilId");

                    b.ToTable("EstadoCivil");
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.OFIM.Models.Nacionalidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Nacionalidad");
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.OFIM.Models.NivelAcademico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NivelAcademico");
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.OFIM.Models.Ocupacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ocupacion");
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.OFIM.Models.PersonaOFIM", b =>
                {
                    b.Property<string>("PersonaOFIMId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Canton")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChildNumber")
                        .HasColumnType("int");

                    b.Property<string>("CoupleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Disability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoCivilId")
                        .HasColumnType("int");

                    b.Property<string>("LatName1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LatName2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicalCondition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobilePhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NacionalidadId")
                        .HasColumnType("int");

                    b.Property<int>("NivelAcademicoId")
                        .HasColumnType("int");

                    b.Property<int>("OcupacionId")
                        .HasColumnType("int");

                    b.Property<string>("PersonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeguroId")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonaOFIMId");

                    b.HasIndex("EstadoCivilId");

                    b.HasIndex("NacionalidadId");

                    b.HasIndex("NivelAcademicoId");

                    b.HasIndex("OcupacionId");

                    b.HasIndex("SeguroId");

                    b.ToTable("PersonaOFIM");
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.OFIM.Models.Seguimiento", b =>
                {
                    b.Property<int>("SeguimientoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConsultaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonaOFIMId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SeguimientoId");

                    b.HasIndex("ConsultaId");

                    b.HasIndex("PersonaOFIMId");

                    b.ToTable("Seguimiento");
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.OFIM.Models.Seguro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Seguro");
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.OFIM.Models.TipoConsulta", b =>
                {
                    b.Property<int>("TipoConsultaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreTipoConsulta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonaOFIMId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TipoConsultaId");

                    b.HasIndex("PersonaOFIMId");

                    b.ToTable("TipoConsulta");
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.PATENTES.Models.ActivityType", b =>
                {
                    b.Property<int>("ActivityTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActivityTypeId");

                    b.ToTable("ActivityType");
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.PATENTES.Models.Applicant", b =>
                {
                    b.Property<int>("ApplicantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicantId");

                    b.ToTable("Applicant");
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.PATENTES.Models.CIIU", b =>
                {
                    b.Property<int>("CIIUId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CIIUId");

                    b.ToTable("CIIU");
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.PATENTES.Models.Establishment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivityTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ApplicantId")
                        .HasColumnType("int");

                    b.Property<int>("CIIUId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DesignNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstablishmentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("NFarm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherActivities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkilledWorkers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnskilledWorkers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WMen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WWomen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebPage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkingHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ActivityTypeId");

                    b.HasIndex("ApplicantId");

                    b.HasIndex("CIIUId");

                    b.HasIndex("EstablishmentTypeId");

                    b.ToTable("Establishment");
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.PATENTES.Models.EstablishmentType", b =>
                {
                    b.Property<int>("EstablishmentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstablishmentTypeId");

                    b.ToTable("EstablishmentType");
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.PATENTES.Models.PersonPatentes", b =>
                {
                    b.Property<string>("PersonId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Canton")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CellphoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FisicID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JuridicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName1F")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName2F")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameJS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("PersonPatentes");
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.PATENTES.Models.RequestReason", b =>
                {
                    b.Property<int>("RequestReasonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestReasonId");

                    b.ToTable("RequestReason");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.OFIM.Models.Consulta", b =>
                {
                    b.HasOne("SYGESTMunicipal.Areas.OFIM.Models.PersonaOFIM", "PersonaOFIM")
                        .WithMany()
                        .HasForeignKey("PersonaOFIMId");

                    b.HasOne("SYGESTMunicipal.Areas.OFIM.Models.TipoConsulta", "TipoConsulta")
                        .WithMany()
                        .HasForeignKey("TipoConsultaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.OFIM.Models.PersonaOFIM", b =>
                {
                    b.HasOne("SYGESTMunicipal.Areas.OFIM.Models.EstadoCivil", "EstadoCivil")
                        .WithMany("PersonaOFIM")
                        .HasForeignKey("EstadoCivilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SYGESTMunicipal.Areas.OFIM.Models.Nacionalidad", "Nacionalidad")
                        .WithMany("PersonaOFIM")
                        .HasForeignKey("NacionalidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SYGESTMunicipal.Areas.OFIM.Models.NivelAcademico", "NivelAcademico")
                        .WithMany("PersonaOFIM")
                        .HasForeignKey("NivelAcademicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SYGESTMunicipal.Areas.OFIM.Models.Ocupacion", "Ocupacion")
                        .WithMany("PersonaOFIM")
                        .HasForeignKey("OcupacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SYGESTMunicipal.Areas.OFIM.Models.Seguro", "Seguro")
                        .WithMany("PersonaOFIM")
                        .HasForeignKey("SeguroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.OFIM.Models.Seguimiento", b =>
                {
                    b.HasOne("SYGESTMunicipal.Areas.OFIM.Models.Consulta", "Consulta")
                        .WithMany()
                        .HasForeignKey("ConsultaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SYGESTMunicipal.Areas.OFIM.Models.PersonaOFIM", "PersonaOFIM")
                        .WithMany()
                        .HasForeignKey("PersonaOFIMId");
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.OFIM.Models.TipoConsulta", b =>
                {
                    b.HasOne("SYGESTMunicipal.Areas.OFIM.Models.PersonaOFIM", "PersonaOFIM")
                        .WithMany()
                        .HasForeignKey("PersonaOFIMId");
                });

            modelBuilder.Entity("SYGESTMunicipal.Areas.PATENTES.Models.Establishment", b =>
                {
                    b.HasOne("SYGESTMunicipal.Areas.PATENTES.Models.ActivityType", "ActivityType")
                        .WithMany("Establishment")
                        .HasForeignKey("ActivityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SYGESTMunicipal.Areas.PATENTES.Models.Applicant", "Applicant")
                        .WithMany("Establishment")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SYGESTMunicipal.Areas.PATENTES.Models.CIIU", "CIIU")
                        .WithMany("Establishment")
                        .HasForeignKey("CIIUId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SYGESTMunicipal.Areas.PATENTES.Models.EstablishmentType", "EstablishmentType")
                        .WithMany("Establishment")
                        .HasForeignKey("EstablishmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
