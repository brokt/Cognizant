using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class RegisterModel : PageModel
    {
        public Models.RegisterModel Input { get; set; }
        public void OnGet()
        {
        }
    }
}
