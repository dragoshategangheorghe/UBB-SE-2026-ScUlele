using System;
using System.IO;
using System.Threading.Tasks;
using BankApp.Client.Services.Interfaces;
using BankApp.Client.Utilities;
using BankApp.Models.DTOs.Transactions;

namespace BankApp.Client.Services.Implementations
{
    public class TransactionApiService : ITransactionApiService
    {
        private readonly ApiService _apiService;
        public TransactionApiService(ApiService apiService)
        {
            // TODO: implement transaction api service logic
            ;
        }

        public Task<TransactionFilterMetadataResponse?> GetFilterMetadataAsync()
        {
            // TODO: load filter metadata
            return default !;
        }

        public Task<TransactionHistoryResponse?> GetHistoryAsync(TransactionHistoryRequest request)
        {
            // TODO: load history
            return default !;
        }

        public Task<TransactionDetailsResponse?> GetTransactionAsync(int transactionId)
        {
            // TODO: load transaction
            return default !;
        }

        public async Task<ExportedFileResult?> ExportTransactionsAsync(TransactionExportRequest request)
        {
            // TODO: implement export logic
            return default !;
        }

        public async Task<ExportedFileResult?> ExportReceiptAsync(int transactionId)
        {
            // TODO: implement export logic
            return default !;
        }

        private static async Task<ExportedFileResult> SaveDownloadAsync(DownloadResponse response)
        {
            // TODO: implement save download logic
            return default !;
        }
    }
}