using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAT.Models
{
    [MetadataType(typeof(cJornadas))]
    public partial class tbJornadas
    {

    }

    public class cJornadas
    {
        [Display(Name = "ID Jornada")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo '{0}' es requerido")]
        public int jor_Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo '{0}' es requerido")]
        [MaxLength(100, ErrorMessage = "Ha excedido el numero maximo de caracteres")]
        [Display(Name = "Descripción")]
        public string jor_Descripcion { get; set; }
        [Display(Name = "Usuario Crea")]
        public int jor_UsuarioCrea { get; set; }
        [Display(Name = "Fecha Crea")]
        public System.DateTime jor_FechaCrea { get; set; }
        [Display(Name = "Usuario Modifíca")]
        public Nullable<int> jor_UsuarioModifica { get; set; }
        [Display(Name = "Fecha Modifíca")]
        public Nullable<System.DateTime> jor_FechaModifica { get; set; }
    }
}