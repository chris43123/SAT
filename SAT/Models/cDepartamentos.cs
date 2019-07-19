using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAT.Models
{
    [MetadataType(typeof(cDepartamentos))]
    public partial class tbDepartamentos
    {
    }
    public class cDepartamentos
    {
        [Display(Name = "Id del departamento:")]
        public string dep_Id { get; set; }
        [Display(Name = "Nombre del departamento:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Requerimos el nombre del departamento")]
        [MaxLength(50, ErrorMessage = "Esta intentando exceder el máximo de caracteres permitidos")]
        public string dep_Descripcion { get; set; }
        [Display(Name = "Usuario creación")]
        public int dep_UsuarioCrea { get; set; }
        [Display(Name = "Fecha de creación")]
        public System.DateTime dep_FechaCrea { get; set; }
        [Display(Name = "Usuario que realizo modificación")]
        public Nullable<int> dep_UsuarioModifica { get; set; }
        [Display(Name = "Fecha de modificacion")]
        public Nullable<System.DateTime> dep_FechaModifica { get; set; }
    }
}