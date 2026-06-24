using System.ComponentModel.DataAnnotations;

namespace DELAVEGA_MVC5.Models;

public class ContactForm
{
    [Required]
    [StringLength(100, ErrorMessage = "Name must be 100 characters or fewer.")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(500, ErrorMessage = "Message must be 500 characters or fewer.")]
    public string Message { get; set; } = string.Empty;
}
