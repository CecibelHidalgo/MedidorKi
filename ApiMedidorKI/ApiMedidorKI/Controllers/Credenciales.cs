using System.ComponentModel.DataAnnotations;

namespace ApiMedidorKI.Controllers
{
    public class Credenciales
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Contrasenia { get; set; }

        [Required]
        public string UsuarioToken { get; set; }

        [Required]
        public string PasswordToken { get; set; }
    }
}