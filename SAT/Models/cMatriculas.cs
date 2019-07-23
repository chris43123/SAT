using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAT.Models
{
    [MetadataType(typeof(cMatriculas))]
    public partial class tbMatriculas
    {

    }

    public class cMatriculas
    {

        [Display(Name = "ID Matricula")]
        public int mat_Id { get; set; }
        [Display(Name = "Alumno")]
        public int alu_Id { get; set; }
        [Display(Name = "Escuela")]
        public int esc_Id { get; set; }
        [Display(Name = "Seccion")]
        public int sec_Id { get; set; }
        [Display(Name = "Carrera")]
        public int car_Id { get; set; }
        [Display(Name = "Año")]
        public int mat_Anio { get; set; }
        [Display(Name = "Usuario Crea")]
        public int mat_UsuarioCrea { get; set; }
        [Display(Name = "Fecha Crea")]
        public System.DateTime mat_FechaCrea { get; set; }
        [Display(Name = "Usuario Modifica")]
        public Nullable<int> mat_UsuarioModifica { get; set; }
        [Display(Name = "Fecha Modifica")]
        public Nullable<System.DateTime> mat_FechaModifica { get; set; }
    }
}