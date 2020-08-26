using JwtIssueExample.Context;
using JwtIssueExample.Exceptions;
using JwtIssueExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace JwtIssueExample.Repositories
{
    public class UserRepository
    {
        private JwtExampleContext _context;

        public UserRepository(JwtExampleContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user ?? throw new UserNotFoundException($"User with Id {id} does not exist.");
        }

        public async Task<User> GetUser(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);
            return user ?? throw new UserNotFoundException($"Login credentials doesn't match an existing user.");
        }
    }
}
