using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sih.Entities.Administration;

namespace Sih.Web.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public IndexModel(
            UserManager<UserEntity> userManager,
            SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Nom & prénom")]
            public string NomPrenom { get; set; }
            [Display(Name = "Nom et prénom")]
            public string Username { get; set; }
            [Phone]
            [Display(Name = "Téléphone")]
            public string PhoneNumber { get; set; }
            [Display(Name = "Profile Picture")]
            public byte[] ProfilePicture { get; set; }
        }

        private async Task LoadAsync(UserEntity user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var firstName = user.NomPrenom;
            var profilePicture = user.ProfilePicture;
            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Username = userName,
                NomPrenom = firstName,
                ProfilePicture = profilePicture
            };
        }


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            var _nomPrenom = user.NomPrenom;
            if (Input.NomPrenom != _nomPrenom)
            {

                user.NomPrenom = Input.NomPrenom;
                await _userManager.UpdateAsync(user);
            }

            if (Request.Form.Files.Count > 0)
            {
                try
                {
                    IFormFile file = Request.Form.Files.FirstOrDefault();
                    using (var dataStream = new MemoryStream())
                    {
                        await file.CopyToAsync(dataStream);
                        user.ProfilePicture = dataStream.ToArray();
                    }
                    await _userManager.UpdateAsync(user);
                }
                catch (Exception ex)
                {
                    StatusMessage = "Error lors du traitement des donnée recues" + ex.Message;
                    return RedirectToPage();
                }

            }
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
