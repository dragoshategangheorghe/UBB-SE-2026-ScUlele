using BankApp.Models.DTOs.Transactions;
using BankApp.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionHistoryService _transactionHistoryService;
        public TransactionsController(ITransactionHistoryService transactionHistoryService)
        {
            // TODO: implement transactions controller logic
            ;
        }

        private int GetAuthenticatedUserId()
        {
            // TODO: load authenticated user id
            return default !;
        }

        [HttpGet("filters")]
        public IActionResult GetFilterMetadata()
        {
            // TODO: load filter metadata
            return default !;
        }

        [HttpPost("history")]
        public IActionResult GetHistory([FromBody] TransactionHistoryRequest request)
        {
            // TODO: load history
            return default !;
        }

        [HttpGet("{transactionId:int}")]
        public IActionResult GetTransaction(int transactionId)
        {
            // TODO: load transaction
            return default !;
        }

        [HttpPost("export")]
        public IActionResult ExportTransactions([FromBody] TransactionExportRequest request)
        {
            // TODO: implement export logic
            return default !;
        }

        [HttpGet("{transactionId:int}/receipt")]
        public IActionResult ExportReceipt(int transactionId)
        {
            // TODO: implement export logic
            return default !;
        }
    }
}