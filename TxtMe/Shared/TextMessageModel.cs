using System.ComponentModel.DataAnnotations;

namespace TxtMe.Shared
{
    public record TextMessageModel([Required]string From, [Required]string To, [Required]string Message);
}
