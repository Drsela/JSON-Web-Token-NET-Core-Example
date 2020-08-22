using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtIssueExample.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message)
        {
        }
    }
}
