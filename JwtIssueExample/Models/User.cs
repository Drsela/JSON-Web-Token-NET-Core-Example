using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JwtIssueExample.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }
    }

    public enum UserType
    {
        Regular = 1,
        Admin = 2,
        SuperUser = 3
    }
}
