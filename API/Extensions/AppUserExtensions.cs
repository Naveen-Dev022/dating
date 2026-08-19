using System;
using API.DTO;
using API.Entities;
using API.Interfaces;

namespace API.Extensions;

public static class AppUserExtensions
{
    public static UserResponseDto ToDto(this AppUser user, ITokenService tokenService)
    {
        return new UserResponseDto
        {
            Id = user.Id,
            DisplayName = user.DisplayName,
            Email = user.DisplayName,
            Token = tokenService.CreateToken(user)
        };
    }
}
