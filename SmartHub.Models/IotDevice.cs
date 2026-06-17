using System.ComponentModel.DataAnnotations;

namespace SmartHub.Models
{
    public class IoTDevice
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Il nome del dispositivo è obbligatorio.")]
        public string? Name { get; set; }
        public bool IsOn { get; set; }
        public double Value { get; set; }
        [Required(AllowEmptyStrings = true, ErrorMessage = "la descrizione del dispositivo è obbligatoria.")]
        public string Description { get; set; } = string.Empty;
    }
}
