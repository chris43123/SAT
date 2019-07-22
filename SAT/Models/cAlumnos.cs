using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAT.Models
{
    [MetadataType(typeof(cAsignaturas))]
    public partial class tbAlumnos
    {
    }
    public class cAlumnos
    {
        [Display(Name = "Id")]
        public int alu_Id { get; set; }

        [Display(Name = "Identidad")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo \"{0}\" es requerido")]
        [MaxLength(100, ErrorMessage = "Excedio el numero maximo de caracteres")]
        public string alu_Identidad { get; set; }

        [Display(Name = "Nombres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo \"{0}\" es requerido")]
        [MaxLength(100, ErrorMessage = "Excedio el numero maximo de caracteres")]
        public string alu_Nombres { get; set; }

        [Display(Name = "Apellido")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo \"{0}\" es requerido")]
        [MaxLength(100, ErrorMessage = "Excedio el numero maximo de caracteres")]
        public string alu_Apellidos { get; set; }

        [Display(Name = "Sexo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo \"{0}\" es requerido")]
        [MaxLength(1, ErrorMessage = "Excedio el numero maximo de caracteres")]
        public string alu_Sexo { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo \"{0}\" es requerido")]
        [MaxLength(10, ErrorMessage = "Excedio el numero maximo de caracteres")]
        public System.DateTime alu_FechaNacimiento { get; set; }

        [Display(Name = "Nombre Encargado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo \"{0}\" es requerido")]
        [MaxLength(100, ErrorMessage = "Excedio el numero maximo de caracteres")]
        public string alu_NombresEncargado { get; set; }

        [Display(Name = "Apellido Encargado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo \"{0}\" es requerido")]
        [MaxLength(100, ErrorMessage = "Excedio el numero maximo de caracteres")]
        public string alu_ApellidosEncargado { get; set; }

        [Display(Name = "Telefono Encargado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo \"{0}\" es requerido")]
        [MaxLength(20, ErrorMessage = "Excedio el numero maximo de caracteres")]
        public string alu_TelefonoEncargado { get; set; }

        [Display(Name = "Usuario Crea")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo \"{0}\" es requerido")]
        [MaxLength(100, ErrorMessage = "Excedio el numero maximo de caracteres")]
        public int alu_UsuarioCrea { get; set; }

        [Display(Name = "Fecha Crea")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo \"{0}\" es requerido")]
        [MaxLength(50, ErrorMessage = "Excedio el numero maximo de caracteres")]
        public System.DateTime alu_FechaCrea { get; set; }

        [Display(Name = "Usuario Modifica")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo \"{0}\" es requerido")]
        [MaxLength(100, ErrorMessage = "Excedio el numero maximo de caracteres")]
        public Nullable<int> alu_UsuarioModifica { get; set; }

        [Display(Name = "Fecha Modifica")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo \"{0}\" es requerido")]
        [MaxLength(50, ErrorMessage = "Excedio el numero maximo de caracteres")]
        public Nullable<System.DateTime> alu_FechaModifica { get; set; }
    }
}