using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Models
{
    public interface IUser
    {
        Task RegisterAsync(RentACar.Models.User.User user);
        Task<RentACar.Models.User.User> GetUserByIdAsync(int id);
        Task<RentACar.Models.User.User> GetUserByEmailAsync(string email);
        Task<List<RentACar.Models.User.User>> GetAllUsersAsync();
    }
}
