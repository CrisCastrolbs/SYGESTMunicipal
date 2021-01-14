using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SYGESTMunicipal.Areas.Identity.Pages.Account.Manage
{
    public class Disable2faModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<Disable2faModel> _logger;

        public Disable2faModel(
            UserManager<IdentityUser> userManager,
            ILogger<Disable2faModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"No se Puede Cargar el usuario con el Id '{_userManager.GetUserId(User)}'.");
            }

            if (!await _userManager.GetTwoFactorEnabledAsync(user))
            {
                throw new InvalidOperationException($"No se Puede Desabilitar 2FA para el Usuario con el Id'{_userManager.GetUserId(User)}' ya que no está habilitado actualmente.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"No se Puede Cargar el usuario con el Id  '{_userManager.GetUserId(User)}'.");
            }

            var disable2faResult = await _userManager.SetTwoFactorEnabledAsync(user, false);
            if (!disable2faResult.Succeeded)
            {
                throw new InvalidOperationException($"No se Pudo Desabilitar 2FA para el Usuario con el Id'{_userManager.GetUserId(User)}'.");
            }

            _logger.LogInformation("El usuario con el Id '{UserId}' ha Desabilitadio 2fa.", _userManager.GetUserId(User));
            StatusMessage = "2fa ha Sido Deshabilitado. Puede Rehabilitarlo 2fa Cuando Configure una Aplicación Autentificadora";
            return RedirectToPage("./TwoFactorAuthentication");
        }
    }
}