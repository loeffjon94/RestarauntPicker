using Microsoft.AspNetCore.Mvc;
using RandomRestaraunt.Data.Models;
using Microsoft.Extensions.Configuration;
using RandomRestaraunt.Data.Repos;

namespace RandomRestaraunt.Controllers
{
    public class BaseController : Controller
    {
        protected readonly RandomRestarauntContext _context;
        protected readonly RestarauntRepo _repo;
        protected readonly IConfiguration _configuration;

        public BaseController(RandomRestarauntContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
            _repo = new RestarauntRepo(context);
        }
    }
}