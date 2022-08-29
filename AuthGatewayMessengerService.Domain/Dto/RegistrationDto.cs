using System.ComponentModel.DataAnnotations;

namespace AuthGatewayMessengerService.Domain.Dto;

public class RegistrationDto
{
    [Required]
    [StringLength(32, MinimumLength = 4)]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(32, MinimumLength = 8)]
    public string Password { get; set; }
}