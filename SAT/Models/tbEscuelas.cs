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
    
    public partial class tbEscuelas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbEscuelas()
        {
            this.tbMatriculas = new HashSet<tbMatriculas>();
        }
    
        public int esc_Id { get; set; }
        public string esc_Codigo { get; set; }
        public string esc_NombreEscuela { get; set; }
        public int esc_Director { get; set; }
        public int esc_Contacto { get; set; }
        public string esc_Telefono { get; set; }
        public string esc_Correo { get; set; }
        public string mun_Id { get; set; }
        public int esc_UsuarioCrea { get; set; }
        public System.DateTime esc_FechaCrea { get; set; }
        public Nullable<int> esc_UsuarioModifica { get; set; }
        public Nullable<System.DateTime> esc_FechaModifica { get; set; }
    
        public virtual tbUsuarios tbUsuarios { get; set; }
        public virtual tbUsuarios tbUsuarios1 { get; set; }
        public virtual tbEmpleados tbEmpleados { get; set; }
        public virtual tbEmpleados tbEmpleados1 { get; set; }
        public virtual tbMunicipios tbMunicipios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbMatriculas> tbMatriculas { get; set; }
    }
}
