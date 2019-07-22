using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAT.Models
{
    [MetadataType(typeof(cNotas))]
    public partial class tbNotas
    {

    }
    public class cNotas
    {
        [Display(Name = "ID Nota")]
        public int not_Id { get; set; }
        [Display(Name = "Asignatura")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo \"{0}\" es requerido")]
        public int asig_Id { get; set; }
        [Display(Name = "Materia")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo \"{0}\" es requerido")]
        public int mat_Id { get; set; }
        [Display(Name = "Usuario Crea")]
        public int not_UsuarioCrea { get; set; }
        [Display(Name = "Fecha crea")]
        public System.DateTime not_FechaCrea { get; set; }
        [Display(Name = "Usuario modifica")]
        public Nullable<int> not_UsuarioModifica { get; set; }
        [Display(Name = "Fecha modifica")]
        public Nullable<System.DateTime> not_FechaModifica { get; set; }
    }
}