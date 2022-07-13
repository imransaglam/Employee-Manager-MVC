using Microsoft.AspNetCore.Identity;

namespace EmployeManager.MVC.Security
{
    public class AppIdentityRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
