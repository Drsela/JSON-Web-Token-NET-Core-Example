using JwtIssueExample.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtIssueExample.Controllers
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params UserType[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }
    }
}
