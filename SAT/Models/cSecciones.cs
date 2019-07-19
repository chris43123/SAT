using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAT.Models
{
    [MetadataType(typeof(cSecciones))]

    public partial class tbSecciones
    {

    }

    public class cSecciones
    {
        [Display(Name ="Id Sección")]
        public int sec_Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Sección")]
        [MaxLength(1, ErrorMessage = "Ha excedido el numero maximo de caracteres")]
        public string sec_Descripcion { get; set; }

        [Display(Name = "Usuario Crea")]
        public int sec_UsuarioCrea { get; set; }

        [Display(Name = "Fecha Crea")]
        public System.DateTime sec_FechaCrea { get; set; }

        [Display(Name = "Usuario Modifica")]
        public Nullable<int> sec_UsuarioModifica { get; set; }

        [Display(Name = "Fecha Modifica")]
        public Nullable<System.DateTime> sec_FechaModifica { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Id Grado")]
        public int jgra_Id { get; set; }
        
    }
}