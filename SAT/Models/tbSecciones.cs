//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAT.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbSecciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbSecciones()
        {
            this.tbMatriculas = new HashSet<tbMatriculas>();
        }
    
        public int sec_Id { get; set; }
        public string sec_Descripcion { get; set; }
        public int sec_UsuarioCrea { get; set; }
        public System.DateTime sec_FechaCrea { get; set; }
        public Nullable<int> sec_UsuarioModifica { get; set; }
        public Nullable<System.DateTime> sec_FechaModifica { get; set; }
        public int jgra_Id { get; set; }
    
        public virtual tbUsuarios tbUsuarios { get; set; }
        public virtual tbUsuarios tbUsuarios1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbMatriculas> tbMatriculas { get; set; }
        public virtual tbJornadaGrados tbJornadaGrados { get; set; }
    }
}
