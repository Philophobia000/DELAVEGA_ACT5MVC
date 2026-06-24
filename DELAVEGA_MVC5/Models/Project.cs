using System.ComponentModel.DataAnnotations;

namespace DELAVEGA_MVC5.Models;

public class Project
{
    public string Id { get; set; } = string.Empty;

    [Required]
    [StringLength(100, ErrorMessage = "Title must be 100 characters or fewer.")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(500, ErrorMessage = "Summary must be 500 characters or fewer.")]
    public string Summary { get; set; } = string.Empty;

    [Required]
    [StringLength(100, ErrorMessage = "Role must be 100 characters or fewer.")]
    public string Role { get; set; } = string.Empty;

    [Required]
    [StringLength(200, ErrorMessage = "Technologies must be 200 characters or fewer.")]
    public string Technologies { get; set; } = string.Empty;

    [Url]
    [StringLength(250, ErrorMessage = "Link must be 250 characters or fewer.")]
    public string Link { get; set; } = string.Empty;
}
