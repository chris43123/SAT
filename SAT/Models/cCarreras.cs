using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAT.Models
{
    [MetadataType(typeof(cCarreras))]
    public partial class tbCarreras
    {

    }
    public class cCarreras
    {
       [Display(Name = "ID Cargo")]
        public int car_Id { get; set; }

        [Display(Name = "Descripcion")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "Ha excedido el numero maximo de caracteres")]
        public string car_Descripcion { get; set; }

        [Display(ShortName = "Nombre Encargado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        public virtual int car_Encargado { get; set; }

        [Display(Name = "Usuario Crea")]
        public int car_UsuarioCrea { get; set; }

        [Display(Name = "Fecha Crea")]
        public System.DateTime car_FechaCrea { get; set; }

        [Display(Name = "Usuario Modifica")]
        public Nullable<int> car_UsuarioModifica { get; set; }

        [Display(Name = "Fecha Modifica")]

        public Nullable<System.DateTime> car_FechaModifica { get; set; }

        public virtual ICollection<tbCarreraAsignaturas> tbCarreraAsignaturas { get; set; }
        public virtual tbEmpleados tbEmpleados { get; set; }
    }
}