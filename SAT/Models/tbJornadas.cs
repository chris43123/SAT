
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
    
public partial class tbJornadas
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public tbJornadas()
    {

        this.tbJornadaGrados = new HashSet<tbJornadaGrados>();

    }


    public int jor_Id { get; set; }

    public string jor_Descripcion { get; set; }

    public int jor_UsuarioCrea { get; set; }

    public System.DateTime jor_FechaCrea { get; set; }

    public Nullable<int> jor_UsuarioModifica { get; set; }

    public Nullable<System.DateTime> jor_FechaModifica { get; set; }



    public virtual tbUsuarios tbUsuarios { get; set; }

    public virtual tbUsuarios tbUsuarios1 { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tbJornadaGrados> tbJornadaGrados { get; set; }

}

}
