using JwtIssueExample.Models;
using Microsoft.AspNetCore.Authorization;

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
