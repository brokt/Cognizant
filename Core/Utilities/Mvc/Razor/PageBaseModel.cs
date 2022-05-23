using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Mvc.Razor
{
    public class PageBaseModel : PageModel
    {
        public string CurrentPageUrl => HttpContext.Request.Path;
    }
}
