using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAT.Models
{
   
        [MetadataType(typeof(cMunicipios))]
        public partial class tbMunicipios
        {

        }
        public class cMunicipios
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
            [Display(Name = "ID Municipio")]
            public string mun_Id { get; set; }
            [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
            [MaxLength(100, ErrorMessage = "Ha excedido el numero maximo de caracteres")]
            [Display(Name = "Decripcion Municipio")]
            public string mun_Descripcion { get; set; }
            [Display(Name = "Usuario Crea")]
            public int mun_UsuarioCrea { get; set; }
            [Display(Name = "Fecha Creacion")]
            public System.DateTime mun_FechaCrea { get; set; }
            [Display(Name = "Usuario Modifica")]
            public Nullable<int> mun_UsuarioModifica { get; set; }
            [Display(Name = "Fecha Modificacion")]
            public Nullable<System.DateTime> mun_FechaModifica { get; set; }
            [Display(Name = "ID Departamento")]
            public string dep_Id { get; set; }
        }
    }
