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
    
    public partial class tbGrados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbGrados()
        {
            this.tbJornadaGrados = new HashSet<tbJornadaGrados>();
        }
    
        public int grad_Id { get; set; }
        public string grad_Descripcion { get; set; }
        public int grad_UsuarioCrea { get; set; }
        public System.DateTime grad_FechaCrea { get; set; }
        public Nullable<int> grad_UsuarioModifica { get; set; }
        public Nullable<System.DateTime> grad_FechaModifica { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbJornadaGrados> tbJornadaGrados { get; set; }
        public virtual tbUsuarios tbUsuarios { get; set; }
        public virtual tbUsuarios tbUsuarios1 { get; set; }
    }
}
