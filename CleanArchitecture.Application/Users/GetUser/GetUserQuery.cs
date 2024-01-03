using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Authenticate.Login
{
    public class GetUserQuery : IRequest<UserDto>, IQuery
    {
        public GetUserQuery(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public string userName { get; set; }
        public string password { get; set;}
    }
}
