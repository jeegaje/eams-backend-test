using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EAMS.Domain.DTOs;
using EAMS.Domain.Models;

namespace EAMS.CoreAPI.Mappers
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