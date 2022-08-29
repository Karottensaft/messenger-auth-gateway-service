using System.ComponentModel.DataAnnotations;

namespace AuthGatewayMessengerService.Domain.Dto;

public class AuthDto
{
    [Required]
    [StringLength(32, MinimumLength = 4)]
    public string Username { get; set; }

    [Required]
    [StringLength(32, MinimumLength = 8)]
    public string Password { get; set; }
}