﻿using BookStore.Blazor.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStore.Blazor.Account
{
    internal sealed class IdentityUserAccessor(UserManager<BookStoreIdentityUser> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<BookStoreIdentityUser> GetRequiredUserAsync(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }
    }
}
