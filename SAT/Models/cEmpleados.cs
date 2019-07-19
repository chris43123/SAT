using System;
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

    }
}