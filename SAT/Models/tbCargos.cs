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
    
    public partial class tbCargos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbCargos()
        {
            this.tbEmpleados = new HashSet<tbEmpleados>();
        }
    
        public int carg_Id { get; set; }
        public string carg_Descripcion { get; set; }
        public int carg_UsuarioCrea { get; set; }
        public System.DateTime carg_FechaCrea { get; set; }
        public Nullable<int> carg_UsuarioModifica { get; set; }
        public Nullable<System.DateTime> carg_FechaModifica { get; set; }
    
        public virtual tbUsuarios tbUsuarios { get; set; }
        public virtual tbUsuarios tbUsuarios1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEmpleados> tbEmpleados { get; set; }
    }
}
