using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Services;

namespace Web.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IRefitApiRepository _refitApiRepository;

        [BindProperty]
        public Models.LoginModel LoginModelInput { get; set; }
        public LoginModel(IRefitApiRepository refitApiRepository)
        {
            _refitApiRepository = refitApiRepository;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var res = await _refitApiRepository.GetClientService<IUsersApi>().LoginUser(new Models.LoginModel()
            {
                Email = LoginModelInput.Email,
                Password = LoginModelInput.Password
            });

            HttpContext.Session.SetString("Token", res.data.token);
            return Redirect("/");
        }
    }
}
