using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAT.Models
{
    [MetadataType(typeof(cCargos))]
    public partial class tbCargos
    {

    }

    public class cCargos
    {
        [Display(Name = "ID Cargo")]
        public int carg_Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "Ha excedido el numero maximo de caracteres")]
        [Display(Name = "Descripcion")]
        public string carg_Descripcion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "Ha excedido el numero maximo de caracteres")]
        [Display(Name = "Usuario Crea")]
        public int carg_UsuarioCrea { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "Ha excedido el numero maximo de caracteres")]
        [Display(Name = "Fecha Crea")]
        public System.DateTime carg_FechaCrea { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "Ha excedido el numero maximo de caracteres")]
        [Display(Name = "Usuario Modifica")]
        public Nullable<int> carg_UsuarioModifica { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "Ha excedido el numero maximo de caracteres")]
        [Display(Name = "Fecha Modifica")]
        public Nullable<System.DateTime> carg_FechaModifica { get; set; }
    }
}