using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users
{
    public static class UserDtoMappingExstension
    {

        public static UserDto MapToUserDto(this Domain.Entities.User user, IMapper mapper)
        => mapper.Map<UserDto>(user);
    }
}
