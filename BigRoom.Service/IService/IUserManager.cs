﻿using BigRoom.Repository.Contexts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.IService
{
    public interface IUserManager
    {
        Task<(SignInResult result, bool? emailConfirm)> SignInAsync(string email, string password, bool rememberMe, bool lockoutOnFailure = false);
        Task<IList<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
        Task<(IdentityResult result, string emailToken)> CreateAsync(ApplicationUser user, string password, string roleId);
        Task<ApplicationUser> GetApplicationUserAsync(string email);
        bool UserIsSignIn(ClaimsPrincipal user);
        Task<ApplicationUser> FindByIdAsync(string userId);
        Task<IdentityResult> ConfirmEmailAsync(ApplicationUser user, string code);
        Task<bool> IsEmailConfirmedAsync(ApplicationUser user);
        Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
        Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string code, string password);
    }
}
