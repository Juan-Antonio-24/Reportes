using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Reportes.Models
{
    public class Reporte
    {
        [Key]
        [Column("id_reporte")]
        public Int16 Id_Reporte { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} del reporte debe ser menor o igual a 50 caracteres")]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Column("urlreporte")]
        public string UrlReporte { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Column("urlvistaprevia")]
        public string UrlVistaPrevia { get; set; }
    }
}
