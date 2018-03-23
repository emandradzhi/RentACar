using RentACar.Models;
using System;
using System.Collections.Generic;
using System.Text;
using RentACar.Models.User;
using System.Threading.Tasks;
using RentACar.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RentACar.Managers
{
    public class UserManager : IUser
    {
        private readonly AppDbContext _contex;
        
        public UserManager()
        {
            this._contex = new AppDbContext();
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _contex.Users.ToListAsync();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _contex.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            List<User> users = await _contex.Users.ToListAsync();
            return users.FirstOrDefault(u => u.UserId == id);
        }

        public async Task RegisterAsync(User user)
        {
            await _contex.Users.AddAsync(user);
            await _contex.SaveChangesAsync();
        }
    }
}
