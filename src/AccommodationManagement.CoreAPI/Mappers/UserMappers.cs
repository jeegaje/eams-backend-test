using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccommodationManagement.Domain.DTOs;
using AccommodationManagement.Domain.Models;

namespace AccommodationManagement.CoreAPI.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                PrimaryContact = user.PrimaryContact
            };
        }

        public static IEnumerable<UserDto> ToDto(this IEnumerable<User> users)
        {
            return users.Select(user => user.ToDto());
        }
    }
}