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
    
    public partial class tbMatriculas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbMatriculas()
        {
            this.tbNotas = new HashSet<tbNotas>();
        }
    
        public int mat_Id { get; set; }
        public int alu_Id { get; set; }
        public int sec_Id { get; set; }
        public int car_Id { get; set; }
        public int mat_Anio { get; set; }
        public int mat_UsuarioCrea { get; set; }
        public System.DateTime mat_FechaCrea { get; set; }
        public Nullable<int> mat_UsuarioModifica { get; set; }
        public Nullable<System.DateTime> mat_FechaModifica { get; set; }
        public int esc_Id { get; set; }
    
        public virtual tbUsuarios tbUsuarios { get; set; }
        public virtual tbUsuarios tbUsuarios1 { get; set; }
        public virtual tbAlumnos tbAlumnos { get; set; }
        public virtual tbCarreras tbCarreras { get; set; }
        public virtual tbSecciones tbSecciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbNotas> tbNotas { get; set; }
        public virtual tbEscuelas tbEscuelas { get; set; }
    }
}
