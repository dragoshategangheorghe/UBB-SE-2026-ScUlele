using BankApp.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;
        public StatisticsController(IStatisticsService statisticsService)
        {
            // TODO: implement statistics controller logic
            ;
        }

        private int GetAuthenticatedUserId()
        {
            // TODO: load authenticated user id
            return default !;
        }

        [HttpGet("spending-by-category")]
        public IActionResult GetSpendingByCategory()
        {
            // TODO: load spending by category
            return default !;
        }

        [HttpGet("income-vs-expenses")]
        public IActionResult GetIncomeVsExpenses()
        {
            // TODO: load income vs expenses
            return default !;
        }

        [HttpGet("balance-trends")]
        public IActionResult GetBalanceTrends()
        {
            // TODO: load balance trends
            return default !;
        }

        [HttpGet("top-recipients")]
        public IActionResult GetTopRecipients()
        {
            // TODO: load top recipients
            return default !;
        }
    }
}