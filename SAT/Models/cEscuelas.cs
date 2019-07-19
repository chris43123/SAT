using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAT.Models
{
    [MetadataType(typeof(cEscuelas))]
    public partial class tbEscuelas
    {
    }

    public class cEscuelas
    {
        [Display(Name = "Codigo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(20, ErrorMessage = "Excedió el número máxio de caracteres")]
        public string esc_Codigo { get; set; }

        [Display(Name = "Nombre Escuela")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "Excedió el número máxio de caracteres")]
        public string esc_NombreEscuela { get; set; }

       
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Director")]
        public int esc_Director { get; set; }

        [Display(Name = "Contacto")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        public int esc_Contacto { get; set; }

        [Display(Name = "Telefono")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(20, ErrorMessage = "Excedió el máximo de caracteres")]
        public string esc_Telefono { get; set; }

        [Display(Name = "Correo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "Excedió el máximo de caracteres")]
        public string esc_Correo { get; set; }

        [Display(Name = "Id Municipio")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="El campo {0} es requerido")]
        [MaxLength(4,ErrorMessage ="Excedió el máximo de caracteres")]
        public string mun_Id { get; set; }

        //[Display(Name ="Usuario crea")]
        //[Required(AllowEmptyStrings = false, ErrorMessage ="El campo {0} es requerido")]
        //[Range(0, int.MaxValue,ErrorMessage ="Ingrese un numero positivo{0}")]
        //public int esc_UsuarioCrea { get; set; }

        //[Display(Name = "Fecha crea")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido")]  
     
        //public System.DateTime esc_FechaCrea { get; set; }

        //[Display(Name = "Usuario modifica")]  
        //public Nullable<int> esc_UsuarioModifica { get; set; }

        //[Display(Name = "Fecha modifica")]
        //public Nullable<System.DateTime> esc_FechaModifica { get; set; }









    }
}
