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
    
    public partial class tbNotas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbNotas()
        {
            this.tbNotaDetalles = new HashSet<tbNotaDetalles>();
        }
    
        public int not_Id { get; set; }
        public int asig_Id { get; set; }
        public int mat_Id { get; set; }
        public int not_UsuarioCrea { get; set; }
        public System.DateTime not_FechaCrea { get; set; }
        public Nullable<int> not_UsuarioModifica { get; set; }
        public Nullable<System.DateTime> not_FechaModifica { get; set; }
    
        public virtual tbMatriculas tbMatriculas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbNotaDetalles> tbNotaDetalles { get; set; }
        public virtual tbAsignaturas tbAsignaturas { get; set; }
    }
}