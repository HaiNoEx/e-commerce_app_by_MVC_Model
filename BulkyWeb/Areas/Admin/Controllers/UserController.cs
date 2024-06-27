using BulkyWeb.Data;
using BulkyWeb.Migrations.Repository.IRepository;
using BulkyWeb.Models;
using BulkyWeb.Models.ViewModels;
using BulkyWeb.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;

		public object CompanyObj { get; private set; }

		public UserController(UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RoleManagement(string userId) {
           
            RoleManagerVM RoleVM = new RoleManagerVM()
            {
                ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId, includeProperties:"Company"),
                RoleList = _roleManager.Roles.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Name
                }),
                CompanyList = _unitOfWork.Company.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            RoleVM.ApplicationUser.Role = _userManager.GetRolesAsync(_unitOfWork.ApplicationUser.Get(u=>u.Id == userId))
                .GetAwaiter().GetResult().FirstOrDefault();
            return View(RoleVM);
        }

        [HttpPost]
		public IActionResult RoleManagement(RoleManagerVM roleManagerVM)
		{
			
            string oldRole = _userManager.GetRolesAsync(_unitOfWork.ApplicationUser.Get(u => u.Id == roleManagerVM.ApplicationUser.Id))
                .GetAwaiter().GetResult().FirstOrDefault();

            ApplicationUser applicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == roleManagerVM.ApplicationUser.Id);

            if (!(roleManagerVM.ApplicationUser.Role == oldRole))
            {
                // Update

                if (roleManagerVM.ApplicationUser.Role == SD.Role_Comp)
                {
                    applicationUser.CompanyId = roleManagerVM.ApplicationUser.CompanyId;
                }
                if (oldRole == SD.Role_Comp)
                {
                    applicationUser.CompanyId = null;
                }

                _unitOfWork.ApplicationUser.Update(applicationUser);
                _unitOfWork.Save();

                _userManager.RemoveFromRoleAsync(applicationUser, oldRole).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(applicationUser, roleManagerVM.ApplicationUser.Role).GetAwaiter().GetResult();


            }
            else
            {
                if (oldRole == SD.Role_Comp && applicationUser.CompanyId != roleManagerVM.ApplicationUser.CompanyId)
                {
                    applicationUser.CompanyId = roleManagerVM.ApplicationUser.CompanyId;
                    _unitOfWork.ApplicationUser.Update(applicationUser);
                    _unitOfWork.Save();
                }
            }
			return RedirectToAction("Index");
		}



		#region APICALLS


		[HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> objUserList = _unitOfWork.ApplicationUser.GetAll(includeProperties:"Company").ToList();
            

            foreach (var user in objUserList)
            {
                user.Role = _userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault();
                if(user.Company == null)
                {
                    user.Company = new Company() { Name = "" };
                }
            }

            return Json(new {data = objUserList });
        }

        [HttpPost]
        public IActionResult LockUnlock([FromBody]string id)
        {
            var objFromDb = _unitOfWork.ApplicationUser.Get(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Lokhing/Unlocking" });

            }

            if(objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                // Lock --> unlock
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);

            }
            _unitOfWork.ApplicationUser.Update(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Operation successful" });
        }

        #endregion
    }
}
