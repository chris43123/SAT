﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAT.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SATEntities : DbContext
    {
        public SATEntities()
            : base("name=SATEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbAsignaturas> tbAsignaturas { get; set; }
        public virtual DbSet<tbCargos> tbCargos { get; set; }
        public virtual DbSet<tbCarreraAsignaturas> tbCarreraAsignaturas { get; set; }
        public virtual DbSet<tbCarreras> tbCarreras { get; set; }
        public virtual DbSet<tbEmpleadoAsignaturas> tbEmpleadoAsignaturas { get; set; }
        public virtual DbSet<tbEmpleados> tbEmpleados { get; set; }
        public virtual DbSet<tbEscuelas> tbEscuelas { get; set; }
        public virtual DbSet<tbGrados> tbGrados { get; set; }
        public virtual DbSet<tbJornadaGrados> tbJornadaGrados { get; set; }
        public virtual DbSet<tbJornadas> tbJornadas { get; set; }
        public virtual DbSet<tbSecciones> tbSecciones { get; set; }
        public virtual DbSet<tbUsuarios> tbUsuarios { get; set; }
        public virtual DbSet<tbPagos> tbPagos { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tbAlumnos> tbAlumnos { get; set; }
        public virtual DbSet<tbMatriculas> tbMatriculas { get; set; }
        public virtual DbSet<tbNotaDetalles> tbNotaDetalles { get; set; }
        public virtual DbSet<tbNotas> tbNotas { get; set; }
        public virtual DbSet<tbDepartamentos> tbDepartamentos { get; set; }
        public virtual DbSet<tbMunicipios> tbMunicipios { get; set; }
    }
}
