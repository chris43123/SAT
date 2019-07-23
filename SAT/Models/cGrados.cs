using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAT.Models
{
    [MetadataType(typeof(cGrados))]

    public partial class tbGrados
    {

    }
    public class cGrados
    {
        [Display(Name = "Id")]
        public int grad_Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo \"{0}\" es requerido")]
        [Display(Name = "Descripcion")]
        [MaxLength(10, ErrorMessage = "Excedio el numero maximo de caracteres")]
        public string grad_Descripcion { get; set; }
        [Display(Name = "Usuario Crea")]
        public int grad_UsuarioCrea { get; set; }
        [Display(Name = "Fecha Crea")]
        public System.DateTime grad_FechaCrea { get; set; }
        [Display(Name = "Usuario Modifica")]
        public Nullable<int> grad_UsuarioModifica { get; set; }
        [Display(Name = "Fecha Modifica")]
        public Nullable<System.DateTime> grad_FechaModifica { get; set; }
    }
}