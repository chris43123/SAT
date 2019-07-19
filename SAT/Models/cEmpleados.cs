﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAT.Models
{
    [MetadataType(typeof(cEmpleados))]
    public partial class tbEmpleados
    {

    }
<<<<<<< HEAD
    public class cEmpleados
    {
        [Display(Name = "Id Encargado")]
        public int emp_Id { get; set; }
        [Display(Name = "Encargado")]
        public string emp_Identidad { get; set; }
        public string emp_Nombres { get; set; }
        public string emp_Apellidos { get; set; }
        public System.DateTime emp_FechaNacimiento { get; set; }
        public string emp_Sexo { get; set; }
        public string emp_Direccion { get; set; }
        public string mun_Id { get; set; }
        public string emp_CorreoElectronico { get; set; }
        public string emp_Telefono { get; set; }
        public int carg_Id { get; set; }
        public System.DateTime emp_FechaIngreso { get; set; }
        public Nullable<System.DateTime> emp_FechadeSalida { get; set; }
        public string emp_RazonSalida { get; set; }
        public int emp_UsuarioCrea { get; set; }
        public System.DateTime emp_FechaCrea { get; set; }
        public Nullable<int> emp_UsuarioModifica { get; set; }
        public Nullable<System.DateTime> emp_FechaModifica { get; set; }

=======
    public partial class cEmpleados
    {
        public int emp_Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido ")]
        [Display(Name = "Identidad")]
        [MaxLength(20, ErrorMessage = "Excedio el numero maximo de caracteres")]
        public string emp_Identidad { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido ")]
        [Display(Name = "Nombres")]
        [MaxLength(100, ErrorMessage = "Excedio el numero maximo de caracteres")]
        public string emp_Nombres { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido ")]
        [Display(Name = "Apellidos")]
        [MaxLength(100, ErrorMessage = "Excedio el numero maximo de caracteres")]
        public string emp_Apellidos { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido ")]
        [Display(Name = "Fecha  Nacimiento")]
        [MaxLength(100, ErrorMessage = "Excedio el numero maximo de caracteres")]
        public System.DateTime emp_FechaNacimiento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido ")]
        [MaxLength(1, ErrorMessage = "Excedio el numero maximo de caracteres")]
        [Display(Name = "Sexo")]
        public string emp_Sexo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido ")]
        [MaxLength(100, ErrorMessage = "Excedio el numero maximo de caracteres")]
        [Display(Name = "Direccion")]
        public string emp_Direccion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido ")]
        //[MaxLength(4, ErrorMessage = "Excedio el numero maximo de caracteres")]
        [Display(Name = "Municipio")]
        public string mun_Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido ")]
        [MaxLength(100, ErrorMessage = "Excedio el numero maximo de caracteres")]
        [Display(Name = "Correo Electronico")]
        public string emp_CorreoElectronico { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido ")]
        [MaxLength(20, ErrorMessage = "Excedio el numero maximo de caracteres")]
        [Display(Name = "Telefono")]
        public string emp_Telefono { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido ")]
        //[MaxLength(100, ErrorMessage = "Excedio el numero maximo de caracteres")]
        [Display(Name = "Cargo")]
        public int carg_Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido ")]
        [MaxLength(100, ErrorMessage = "Excedio el numero maximo de caracteres")]
        [Display(Name = "Fecha  Ingreso")]
        public System.DateTime emp_FechaIngreso { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido ")]
        [MaxLength(100, ErrorMessage = "Excedio el numero maximo de caracteres")]
        [Display(Name = "Fecha  Salida")]
        public Nullable<System.DateTime> emp_FechadeSalida { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido ")]
        [MaxLength(250, ErrorMessage = "Excedio el numero maximo de caracteres")]
        [Display(Name = "Razón  Salida")]
        public string emp_RazonSalida { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido ")]
        [MaxLength(100, ErrorMessage = "Excedio el numero maximo de caracteres")]
        [Display(Name = "Usuario Crea")]
        public int emp_UsuarioCrea { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido ")]
        [MaxLength(100, ErrorMessage = "Excedio el numero maximo de caracteres")]
        [Display(Name = "Fecha Crea")]
        public System.DateTime emp_FechaCrea { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido ")]
        [MaxLength(100, ErrorMessage = "Excedio el numero maximo de caracteres")]
        [Display(Name = "Usuario Modifica")]
        public Nullable<int> emp_UsuarioModifica { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es requerido ")]
        [MaxLength(100, ErrorMessage = "Excedio el numero maximo de caracteres")]
        [Display(Name = "Fecha Modifica")]
        public Nullable<System.DateTime> emp_FechaModifica { get; set; }
>>>>>>> 801e90b4a4134c06c29fc04733fdb1a6bfc5c7c0
    }
}