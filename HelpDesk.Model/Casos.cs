using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Model
{
    public class Casos
    {
        public int Id { set; get; }
        [Required(ErrorMessage = "El campo Descripcion del Problema es requerido")]
        public string DescripcionProblema { set; get; }

        [Required(ErrorMessage = "El campo Nivel de Criticidad es requerido")]
        public int Nivel { set; get; }
        public int Estado { set; get; }
        public DateTime FechaCreacion { set; get; }
        [Required(ErrorMessage = "El campo Nombre Contacto es requerido")]
        [MaxLength(50)]
        public string NombreContacto { set; get; }
        [Required(ErrorMessage = "El campo Telefono Contacto es requerido")]
        [MaxLength(50)]
        public string TelefonoContacto { set; get; }
        [Required(ErrorMessage = "El campo Direccion es requerido")]
        public string DireccionContacto { set; get; }
        public int ProvinciaContacto { set; get; }

        public DateTime? FechaResolucion { set; get; }
        public string ObservacionesResolucion { set; get; }
        public DateTime? FechaInicioProceso { set; get; }
        [MaxLength(50)]
        public string NombrePersonaResuelve { set; get; }
        public string MotivoRechazo { set; get; }
        public string DescripcionResolucion { set; get; }
    }
}
