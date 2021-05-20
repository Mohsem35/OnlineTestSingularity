using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieAPI.Areas.Admin.Models;
using MovieAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private MovieDbContext _db;
        private UserManager<IdentityUser> _userManager;
        public RoleController(RoleManager<IdentityRole> roleManager, MovieDbContext db, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            ViewBag.Roles = roles;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name)
        //parameter "name" ar cshtml page er input field er "name" same hote hobe for data binding
        {
            IdentityRole role = new IdentityRole();
            role.Name = name;
            var isExist = await _roleManager.RoleExistsAsync(role.Name);
            //checks if the role already exists
            if (isExist)
            {
                ViewBag.name = name;
                ViewBag.message = "This role already exists";
                return View();
            }
            var result = await _roleManager.CreateAsync(role);
            //create a new role
            if (result.Succeeded)
            {
                TempData["save"] = "Role has been created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            ViewBag.id = role.Id;
            ViewBag.name = role.Name;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, string name)
        {

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            role.Name = name;
            var isExist = await _roleManager.RoleExistsAsync(role.Name);
            if (isExist)
            {
                ViewBag.mgs = "This role is aldeady exist";
                ViewBag.name = name;
                return View();
            }
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                TempData["save"] = "Role has been updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                TempData["delete"] = "Role has been deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Assign()
        {
            ViewData["UserId"] = new SelectList(_db.ApplicationUsers.Where(w => w.LockoutEnd < DateTime.Now || w.LockoutEnd == null).ToList(), "Id", "UserName");
            //_db.ApplicationUsers = means it gives all application users list
            ViewData["RoleId"] = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");
            //why name, name(value, display 2 tai name)
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Assign(RoleUserVm roleUser)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(c => c.Id == roleUser.UserId);
            var isCheckRoleAssign = await _userManager.IsInRoleAsync(user, roleUser.RoleId);
            if (isCheckRoleAssign)
            {
                ViewBag.mgs = "This user is being already assigned in this role.";
                ViewData["UserId"] = new SelectList(_db.ApplicationUsers.Where(w => w.LockoutEnd < DateTime.Now || w.LockoutEnd == null).ToList(), "Id", "UserName");
                ViewData["RoleId"] = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");
                return View();
            }

            var role = await _userManager.AddToRoleAsync(user, roleUser.RoleId);
            if (role.Succeeded)
            {
                TempData["save"] = "User Role assigned.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult AssignUserRole()
        {
            var result = from ur in _db.UserRoles
                         join r in _db.Roles on ur.RoleId equals r.Id
                         join a in _db.ApplicationUsers on ur.UserId equals a.Id
                         select new UserRoleMapping()
                         {
                             UserId = ur.UserId,
                             RoleId = ur.RoleId,
                             UserName = a.UserName,
                             RoleName = r.Name
                         };
            ViewBag.UserRoles = result;
            return View();
        }
        //role table er je id, user table er roleid er sathe seita match kore kina 
    }
}
