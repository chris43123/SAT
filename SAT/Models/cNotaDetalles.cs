using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAT.Models
{
       [MetadataType(typeof(cNotaDetalles))]
      public partial class tbNotaDetalles
        {

        }
        public class cNotaDetalles
        {
            [Display(Name = "Id")]
            public int notd_Id { get; set; }
            [Display(Name = "Id Nota")]
            public int not_Id { get; set; }
            [Display(Name = "Nota Acumulado 1")]
            public Nullable<decimal> notd_Acumulado1 { get; set; }
            [Display(Name = "Examen 1")]
            public Nullable<decimal> notd_Examen1 { get; set; }
            [Display(Name = "Nota Acumulado 2")]
            public Nullable<decimal> notd_Acumulado2 { get; set; }
            [Display(Name = "Examen 2")]
            public Nullable<decimal> notd_Examen2 { get; set; }
            [Display(Name = "Nota Acumulado 3")]
            
            public Nullable<decimal> notd_Acumulado3 { get; set; }
            [Display(Name = "Examen 3")]
            
            public Nullable<decimal> notd_Examen3 { get; set; }
            [Display(Name = "Nota Acumulado 4")]
            public Nullable<decimal> notd_Acumulado4 { get; set; }
            [Display(Name = "Examen 4")]
            public Nullable<decimal> notd_Examen4 { get; set; }
            [Display(Name = "Usuario Crea")]
            public int notd_UsuarioCrea { get; set; }
            [Display(Name = "Fecha Crea")]
            public System.DateTime notd_FechaCrea { get; set; }
            [Display(Name = "Usurio Modifica")]
            public Nullable<int> notd_UsuarioModifica { get; set; }
            [Display(Name = "Fecha Modifica")]
            public Nullable<System.DateTime> notd_FechaModifica { get; set; }
        }
 }
