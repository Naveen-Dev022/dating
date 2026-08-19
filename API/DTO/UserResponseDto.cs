using System;

namespace API.DTO;

public class UserResponseDto
{
    public required string Id { get; set; }
    public required string Email { get; set; }
    public required string DisplayName { get; set; }
    public string? imageUrl { get; set; }
    public required string Token { get; set; }
}
