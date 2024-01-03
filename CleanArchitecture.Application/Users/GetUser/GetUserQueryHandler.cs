using AutoMapper;
using CleanArchitecture.Application.Users;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Authenticate.Login
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(
                u => u.Username == request.userName && u.Password == request.password,
                cancellationToken: cancellationToken
                );
        if (user == null)
            throw new NotFoundException($"Could not find UserName '{request.userName}'");
        return user.MapToUserDto(_mapper);
        }
    }
}
