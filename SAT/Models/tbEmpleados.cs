
//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
public partial class tbEmpleados
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public tbEmpleados()
    {

        this.tbCarreras = new HashSet<tbCarreras>();

        this.tbEmpleadoAsignaturas = new HashSet<tbEmpleadoAsignaturas>();

        this.tbEscuelas = new HashSet<tbEscuelas>();

        this.tbEscuelas1 = new HashSet<tbEscuelas>();

    }


    public int emp_Id { get; set; }

    public string emp_Identidad { get; set; }

    public string emp_Nombres { get; set; }

    public string emp_Apellidos { get; set; }

    public Nullable<System.DateTime> emp_FechaNacimiento { get; set; }

    public string emp_Sexo { get; set; }

    public string emp_Direccion { get; set; }

    public string mun_Id { get; set; }

    public string emp_CorreoElectronico { get; set; }

    public string emp_Telefono { get; set; }

    public int carg_Id { get; set; }

    public System.DateTime emp_FechaIngreso { get; set; }

    public Nullable<System.DateTime> emp_FechadeSalida { get; set; }

    public string emp_RazonSalida { get; set; }

    public int emp_UsuarioCrea { get; set; }

    public System.DateTime emp_FechaCrea { get; set; }

    public Nullable<int> emp_UsuarioModifica { get; set; }

    public Nullable<System.DateTime> emp_FechaModifica { get; set; }



    public virtual tbUsuarios tbUsuarios { get; set; }

    public virtual tbUsuarios tbUsuarios1 { get; set; }

    public virtual tbCargos tbCargos { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tbCarreras> tbCarreras { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tbEmpleadoAsignaturas> tbEmpleadoAsignaturas { get; set; }

    public virtual tbMunicipios tbMunicipios { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tbEscuelas> tbEscuelas { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tbEscuelas> tbEscuelas1 { get; set; }

}

}
