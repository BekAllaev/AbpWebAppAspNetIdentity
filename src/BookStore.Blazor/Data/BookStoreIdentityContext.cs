using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OMSBlazor.EntityFrameworkCore;

namespace BookStore.Blazor.Data
{
    public class BookStoreIdentityContext(DbContextOptions<BookStoreIdentityContext> options) : IdentityDbContext<BookStoreIdentityUser>(options)
    {
    }
}
