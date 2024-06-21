using BulkyWeb.Data;
using BulkyWeb.Models;
using BulkyWeb.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db
        )
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        public void Initialize()
        {

            // Migration if they are not applied
            try
            {
                if(_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex) { 

            }


            // Create roles if they are not created
            if (!_roleManager.RoleExistsAsync(SD.Role_Cust).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Cust)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Comp)).GetAwaiter().GetResult();
                // if roles are not created, create admin user as well


                _userManager.CreateAsync(new ApplicationUser
                {
                    Email = "admin@test.com",
                    UserName = "Admin",
                    PhoneNumber = "1234567890",
                    StreetAddress = "Tu tri Hoang Mai",
                    State = "East Laos",
                    PostalCode = "12345",
                    City = "Thu Do Gio Ngan"
                }, "Hai12345").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@test.com");
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
            }
            return;
        }
        
        
    }
}
