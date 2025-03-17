using BankApp.Models.DTOs.Dashboard;
using Microsoft.AspNetCore.Mvc;
using BankApp.Server.Services.Interfaces;

namespace BankApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashService;
        public DashboardController(IDashboardService dashService)
        {
            // TODO: implement dashboard controller logic
            ;
        }

        [HttpGet]
        public IActionResult GetDashboard()
        {
            // TODO: load dashboard
            return default !;
        }
    }
}