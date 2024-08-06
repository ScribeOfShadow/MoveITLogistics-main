using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestDbCRUD.Data;
using TestDbCRUD.Models;
using TestDbCRUD.Models.Domain;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace TestDbCRUD.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly MoveItDbContext moveItDbContext;

        public UserAccountController(MoveItDbContext moveItDbContext)
        {
            this.moveItDbContext = moveItDbContext;
        }

        /*  // GET: UserAccounts
          public async Task<IActionResult> Index()
          {
                return _context.UserAccount != null ? 
                            View(await _context.UserAccount.ToListAsync()) :
                            Problem("Entity set 'MoveItDbContext.UserAccount'  is null.");
          }

          // GET: UserAccounts/Details/5
          public async Task<IActionResult> Details(int? id)
          {
              if (id == null || _context.UserAccount == null)
              {
                  return NotFound();
              }

              var userAccount = await _context.UserAccount
                  .FirstOrDefaultAsync(m => m.UserID == id);
              if (userAccount == null)
              {
                  return NotFound();
              }

              return View(userAccount);
          }*/

        [HttpGet]
        public async Task<IActionResult> ListView()
        {
            var useraccounts = await moveItDbContext.UserAccount.ToListAsync();
            return View(useraccounts);
        }

        // GET: UserAccounts/Create
        [HttpGet]
        public IActionResult Create()
        {

            var roles = moveItDbContext.RoleType.ToList();

            // Use ViewBag to pass the roles to the view
            ViewBag.Roles = new SelectList(roles, "RoleName", "RoleName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserAccountAdd addUserRequest)
        {
            var selectedRoleName = addUserRequest.RoleName;

            // Retrieve the corresponding RoleType entity based on the selected role name
            var selectedRole = moveItDbContext.RoleType.FirstOrDefault(r => r.RoleName == selectedRoleName);

            if (selectedRole != null)
            {
                var useraccount = new UserAccount()
                {
                    // UserId = Guid.NewGuid(),
                    UserName = addUserRequest.UserName,
                    Password = addUserRequest.Password,
                    ConfirmPassword = addUserRequest.ConfirmPassword,
                    Role = selectedRole // Set the Role property to the selectedRole
                };

                await moveItDbContext.UserAccount.AddAsync(useraccount);
                await moveItDbContext.SaveChangesAsync();
                return RedirectToAction("Create");
            }
            else
            {
                // Handle the case where the selected role does not exist
                // You might want to return an error message or redirect to a different view
                ModelState.AddModelError("RoleName", "Invalid role selected");
                return View();
            }
        }


        //
        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.ShowNavigationBar = false;
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserAccount user)
        {
            using (moveItDbContext)
            {
                var useraccount = moveItDbContext.UserAccount
                    .Include(u => u.Role)
                    .FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);

                if (useraccount != null)
                {
                    // Check the user's role and redirect accordingly
                    if (useraccount.Role != null)
                    {
                        if (useraccount.Role.RoleName == "Admin")
                        {
                            // Redirect to the admin view
                            return RedirectToAction("Index", "Home");
                        }
                        else if (useraccount.Role.RoleName == "Driver")
                        {
                            // Redirect to the driver view
                            return RedirectToAction("IndexDriver", "Home");
                        }
                    }

                    // Handle other roles or cases here

                    // If no specific role or view is defined, you can return a generic view
                    return RedirectToAction("View", "Orders");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is wrong");
                }
            }
            return View();
        }


        [HttpGet]
        public IActionResult Newregister()
        {
            return View("Create");
        }



        /*  // GET: UserAccounts/Edit/5
          public async Task<IActionResult> Edit(int? id)
          {
              if (id == null || _context.UserAccount == null)
              {
                  return NotFound();
              }

              var userAccount = await _context.UserAccount.FindAsync(id);
              if (userAccount == null)
              {
                  return NotFound();
              }
              return View(userAccount);
          }

          // POST: UserAccounts/Edit/5
          // To protect from overposting attacks, enable the specific properties you want to bind to.
          // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Edit(int id, [Bind("UserID,UserName,Name,Surname,Email,StreetAdress,Suburb,PostalCode,Password,ConfirmPassword")] UserAccount userAccount)
          {
              if (id != userAccount.UserID)
              {
                  return NotFound();
              }

              if (ModelState.IsValid)
              {
                  try
                  {
                      _context.Update(userAccount);
                      await _context.SaveChangesAsync();
                  }
                  catch (DbUpdateConcurrencyException)
                  {
                      if (!UserAccountExists(userAccount.UserID))
                      {
                          return NotFound();
                      }
                      else
                      {
                          throw;
                      }
                  }
                  return RedirectToAction(nameof(Index));
              }
              return View(userAccount);
          }

          // GET: UserAccounts/Delete/5
          public async Task<IActionResult> Delete(int? id)
          {
              if (id == null || _context.UserAccount == null)
              {
                  return NotFound();
              }

              var userAccount = await _context.UserAccount
                  .FirstOrDefaultAsync(m => m.UserID == id);
              if (userAccount == null)
              {
                  return NotFound();
              }

              return View(userAccount);
          }

          // POST: UserAccounts/Delete/5
          [HttpPost, ActionName("Delete")]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> DeleteConfirmed(int id)
          {
              if (_context.UserAccount == null)
              {
                  return Problem("Entity set 'MoveItDbContext.UserAccount'  is null.");
              }
              var userAccount = await _context.UserAccount.FindAsync(id);
              if (userAccount != null)
              {
                  _context.UserAccount.Remove(userAccount);
              }

              await _context.SaveChangesAsync();
              return RedirectToAction(nameof(Index));
          }

          private bool UserAccountExists(int id)
          {
            return (_context.UserAccount?.Any(e => e.UserID == id)).GetValueOrDefault();
          }*/
    }
}