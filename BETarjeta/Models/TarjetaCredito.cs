using System.ComponentModel.DataAnnotations;

namespace BETarjeta.Models
{
    public class TarjetaCredito
    {

        [Required]  public int Id { get; set; }
        [Required]  public string Titular { get; set; }
        [Required]  public string NumeroTarjeta { get; set; }
        [Required]  public string FechaExpiracion { get; set;}
        [Required] public int cvv { get; set;}
    }
}
