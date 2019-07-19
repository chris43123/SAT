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
        [Display(Name = "Descripcion")]
        [MaxLength(1000, ErrorMessage = "Ha excedido el numero maximo de caracteres")]
        public string carg_Descripcion { get; set; }

        [Display(Name = "Usuario Crea")]
        public int carg_UsuarioCrea { get; set; }

        [Display(Name = "Fecha Crea")]
        public System.DateTime carg_FechaCrea { get; set; }

        [Display(Name = "Usuario Modifica")]
        public Nullable<int> carg_UsuarioModifica { get; set; }

        [Display(Name = "Fecha Modifica")]
        public Nullable<System.DateTime> carg_FechaModifica { get; set; }
    }
}