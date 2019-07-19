using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAT.Models
{
    [MetadataType(typeof(cAsignaturas))]
    public partial class tbAsignaturas
    {
        
    }
    public class cAsignaturas
    {
        [Display(Name = "ID Asignatura")]
        public int asig_Id { get; set; }
        [Display(Name = "Nombre Asignatura")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo \"{0}\" es requerido")]
        [MaxLength(100, ErrorMessage = "Excedio el numero maximo de caracteres")]
        public string asig_Descripcion { get; set; }
        [Display(Name = "Semetre de Asignatura")]
        [Required(AllowEmptyStrings = true, ErrorMessage = "El campo \"{0}\" es requerido")]
        public Nullable<bool> asig_Semestral { get; set; }
        [Display(Name = "Usuario Crea")]
        public int asig_UsuarioCrea { get; set; }
        [Display(Name = "Fecha Creación")]
        public System.DateTime asig_FechaCrea { get; set; }
        [Display(Name = "Usuario Modifica")]
        public Nullable<int> asig_UsuarioModifica { get; set; }
        [Display(Name = "Fecha de Modificación")]
        public Nullable<System.DateTime> asig_FechaModifica { get; set; }

    }
}