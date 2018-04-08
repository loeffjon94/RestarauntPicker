using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RandomRestaraunt.Models;
using RandomRestaraunt.Data.Models;
using Microsoft.Extensions.Configuration;

namespace RandomRestaraunt.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(RandomRestarauntContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        public IActionResult Index()
        {
            var restaraunts = _repo.GetUsableRestaraunts();
            return View(restaraunts);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
