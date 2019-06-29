using GetADoctor.Data.Infrastructure;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GetADoctor.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersManageController : Controller
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Admin/UsersManage
        public ActionResult Index()
        {
            
            var users = UserManager.Users.ToList();
            ApplicationDbContext db = new ApplicationDbContext();
            
            List<string> roles = new List<string>();
            foreach(var item in users)
            {                
                var user_role_id = item.Roles.FirstOrDefault().RoleId;
                string role_name = db.Roles.Where(x => x.Id == user_role_id).FirstOrDefault().Name;
                roles.Add(role_name);
            }
            ViewBag.roles = roles;

            return View(users);
        }
    }
}