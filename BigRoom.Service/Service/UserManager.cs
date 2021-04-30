using AutoMapper;
using BigRoom.Repository.Contexts;
using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BigRoom.Service.Service
{
    public class UserManager : IUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserProfileService _profileService;

        public UserManager(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,IUserProfileService profileService)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
            this._profileService = profileService;
        }
        public bool UserIsSignIn(ClaimsPrincipal user)
        {
            return _signInManager.IsSignedIn(user);
        }
      
        public async Task<(IdentityResult result, string emailToken)> CreateAsync(ApplicationUser user, string password,string roleId)
        {
           
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                var role = await _roleManager.FindByIdAsync(roleId);
                await _userManager.AddToRoleAsync(user, role?.Name);
                await _profileService.AddUserProfileAsync(user.Id);
                var emailToken= await _userManager.GenerateEmailConfirmationTokenAsync(user);
                return (result, emailToken);
            }
            return (result, null);
        }

        public async Task<ApplicationUser> GetApplicationUserAsync(string email)
        {
            return await this._userManager.FindByEmailAsync(email);
        }

        public async Task<IList<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync()
        {
            return (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<(SignInResult result, bool? emailConfirm)> SignInAsync(string email, string password, bool rememberMe, bool lockoutOnFailure = false)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(email);
                bool emailStatus = await _userManager.IsEmailConfirmedAsync(user);
                return (result, emailStatus);
            }
            return (result, null);
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(ApplicationUser user, string code)
        {
            return await _userManager.ConfirmEmailAsync(user,code);
        }

        public async Task<bool> IsEmailConfirmedAsync(ApplicationUser user)
        {
            return await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string code, string password)
        {
            return await _userManager.ResetPasswordAsync(user,code,password);
        }
    }
}