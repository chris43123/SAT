
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
    
public partial class tbAsignaturas
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public tbAsignaturas()
    {

        this.tbNotas = new HashSet<tbNotas>();

        this.tbCarreraAsignaturas = new HashSet<tbCarreraAsignaturas>();

        this.tbEmpleadoAsignaturas = new HashSet<tbEmpleadoAsignaturas>();

    }


    public int asig_Id { get; set; }

    public string asig_Descripcion { get; set; }

    public bool asig_Semestral { get; set; }

    public int asig_UsuarioCrea { get; set; }

    public System.DateTime asig_FechaCrea { get; set; }

    public Nullable<int> asig_UsuarioModifica { get; set; }

    public Nullable<System.DateTime> asig_FechaModifica { get; set; }



    public virtual tbUsuarios tbUsuarios { get; set; }

    public virtual tbUsuarios tbUsuarios1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tbNotas> tbNotas { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tbCarreraAsignaturas> tbCarreraAsignaturas { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tbEmpleadoAsignaturas> tbEmpleadoAsignaturas { get; set; }

}

}
