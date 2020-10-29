using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using SYGESTMunicipal.Areas.Admin.Models;
using SYGESTMunicipal.Utility;

namespace SYGESTMunicipal.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        //public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "La clave debe contener almenos 6 caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "La Contraseña y la Confirmación de la Contraseña No Coinciden.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Cédula")]
            public string IdPassport { get; set; }

            [Display(Name = "Nombre")]
            public string Name { get; set; }

            [Display(Name = "Primer Apellido")]
            public string LastName1 { get; set; }
            
            [Display(Name = "Segundo Apellido")]
            public string LastName2 { get; set; }
            
            [Display(Name = "Dirección Exacta")]
            public string Address { get; set; }

            [Display(Name = "Distrito")]
            public string District { get; set; }

            [Display(Name = "Cantón")]
            public string Canton { get; set; }

            [Display(Name = "Provincia")]
            public string Province { get; set; }

            [Display(Name = "N° Teléfono")]
            public string PhoneNumber { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            string role = Request.Form["rdUserRole"].ToString();


            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    IdPassport = Input.IdPassport,
                    Name = Input.Name,
                    LastName1 = Input.LastName1,
                    LastName2 = Input.LastName2,
                    Address = Input.Address,
                    District = Input.District,
                    Canton = Input.Canton,
                    Province = Input.Province,
                    PhoneNumber = Input.PhoneNumber
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync(SD.ManagerUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.ManagerUser));
                    }
                    if (!await _roleManager.RoleExistsAsync(SD.Guest))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.Guest));
                    }
                    if (!await _roleManager.RoleExistsAsync(SD.FrontDeskUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.FrontDeskUser));
                    }
                    if (!await _roleManager.RoleExistsAsync(SD.AdminOFIM))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.AdminOFIM));
                    }
                    if (!await _roleManager.RoleExistsAsync(SD.AdminOFGA))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.AdminOFGA));
                    }
                    if (!await _roleManager.RoleExistsAsync(SD.AdminOFPA))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.AdminOFPA));
                    }
                    if (!await _roleManager.RoleExistsAsync(SD.CollManager))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.CollManager));
                    }
                          if (role == SD.CollManager)
                        {
                            await _userManager.AddToRoleAsync(user, SD.CollManager);
                        }
                        else              
                        if (role == SD.FrontDeskUser)
                        {
                            await _userManager.AddToRoleAsync(user, SD.FrontDeskUser);
                        }
                        else
                        {
                            if (role == SD.AdminOFIM)
                            {
                                await _userManager.AddToRoleAsync(user, SD.AdminOFIM);
                            }
                            else
                            {
                                if (role == SD.AdminOFGA)
                            {
                                await _userManager.AddToRoleAsync(user, SD.AdminOFGA);
                            }
                                else
                                {
                                    if (role == SD.AdminOFPA)
                                    {
                                        await _userManager.AddToRoleAsync(user, SD.AdminOFPA);
                                    }
                                    else
                                    {
                                        if (role == SD.ManagerUser)
                                        {
                                            await _userManager.AddToRoleAsync(user, SD.ManagerUser);
                                        }
                                        else
                                    {
                                         await _userManager.AddToRoleAsync(user, SD.Guest);
                                         await _signInManager.SignInAsync(user, isPersistent: false);
                                         return LocalRedirect(returnUrl);
                                    }
                                }
                            }
                        }
                    }
        
                    _logger.LogInformation("Usuario creado con una nueva cuenta con contraseña.");

                    return RedirectToAction("Index", "User", new { area = "Admin" });

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}