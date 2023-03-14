using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sale_With_Maui.API.Data;
using Sale_With_Maui.Shared.DTOs;
using Sale_With_Maui.Shared.Entities;

namespace Sale_With_Maui.API.Helpers
{

    public class UserHelper : IUserHelper
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _rolManager;
        private readonly SignInManager<User> _signInManager;

        public UserHelper(DataContext context, UserManager<User> userManager, RoleManager<IdentityRole> rolManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _rolManager = rolManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExist = await _rolManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await _rolManager.CreateAsync(new IdentityRole
                {
                    Name= roleName
                });
            }
        }

        public async Task<User?> GetUserAsync(string email)
        {
            return await _context.Users
                .Include(u => u.City!)
                .ThenInclude(c => c.State)
                .ThenInclude(s => s.Country)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginDTO model)
        {
            return await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
