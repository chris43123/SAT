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
    
    public partial class tbEmpleadoAsignaturas
    {
        public int empa_Id { get; set; }
        public int emp_Id { get; set; }
        public int asig_Id { get; set; }
        public int empa_UsuarioCrea { get; set; }
        public System.DateTime empa_FechaCrea { get; set; }
        public Nullable<int> empa_UsuarioModifica { get; set; }
        public Nullable<int> empa_FechaModifica { get; set; }
    
        public virtual tbAsignaturas tbAsignaturas { get; set; }
        public virtual tbEmpleados tbEmpleados { get; set; }
        public virtual tbUsuarios tbUsuarios { get; set; }
        public virtual tbUsuarios tbUsuarios1 { get; set; }
    }
}
