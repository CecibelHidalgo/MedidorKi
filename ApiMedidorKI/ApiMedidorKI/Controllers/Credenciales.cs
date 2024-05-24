using System.ComponentModel.DataAnnotations;

namespace ApiMedidorKI.Controllers
{
    public class Credenciales
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Clave { get; set; }

        [Required]
        public string UsuarioToken { get; set; }

        [Required]
        public string ClaveToken { get; set; }
    }
}