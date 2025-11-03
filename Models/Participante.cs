using System.ComponentModel.DataAnnotations;

namespace ComunidadConectada.Models
{
    public enum Genero
    {
        Masculino = 1,
        Femenino = 2,
        Otro = 3
    }

    public class Participante
    {
        [Required(ErrorMessage = "La identificación es obligatoria.")]
        [Display(Name = "Identificación")]
        public string Identificacion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los apellidos son obligatorios.")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; } = string.Empty;

        [Phone(ErrorMessage = "El teléfono no tiene un formato válido.")]
        [Display(Name = "Teléfono")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
        [Display(Name = "Correo electrónico")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El género es obligatorio.")]
        [Display(Name = "Género")]
        public Genero? Genero { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria.")]
        [Range(1, 120, ErrorMessage = "La edad debe estar entre 1 y 120.")]
        [Display(Name = "Edad")]
        public int? Edad { get; set; }

        // Comportamiento de dominio sencillo
        public void Normalizar()
        {
            Identificacion = Identificacion?.Trim() ?? string.Empty;
            Nombre = Nombre?.Trim() ?? string.Empty;
            Apellidos = Apellidos?.Trim() ?? string.Empty;
            Telefono = string.IsNullOrWhiteSpace(Telefono) ? null : Telefono.Trim();
            Correo = Correo?.Trim().ToLowerInvariant() ?? string.Empty;
        }
    }
}
