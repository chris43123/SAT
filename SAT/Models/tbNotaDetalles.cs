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
    
    public partial class tbNotaDetalles
    {
        public int notd_Id { get; set; }
        public int not_Id { get; set; }
        public decimal notd_Examen1 { get; set; }
        public decimal notd_Examen2 { get; set; }
        public decimal notd_Examen3 { get; set; }
        public decimal notd_Examen4 { get; set; }
        public decimal notd_Acumulado1 { get; set; }
        public decimal notd_Acumulado2 { get; set; }
        public decimal notd_Acumulado3 { get; set; }
        public decimal notd_Acumulado4 { get; set; }
        public int notd_UsuarioCrea { get; set; }
        public System.DateTime notd_FechaCrea { get; set; }
        public Nullable<int> notd_UsuarioModifica { get; set; }
        public Nullable<System.DateTime> notd_FechaModifica { get; set; }
    
        public virtual tbNotas tbNotas { get; set; }
    }
}
