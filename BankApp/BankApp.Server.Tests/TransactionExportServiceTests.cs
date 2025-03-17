using System.IO.Compression;
using System.Text;
using BankApp.Models.DTOs.Transactions;
using BankApp.Server.Services.Implementations;
using BankApp.Server.Services.Interfaces;
using Xunit;

namespace BankApp.Server.Tests;
public class TransactionExportServiceTests
{
    [Fact]
    public void ExportStatement_ReturnsCsvWithExpectedHeader()
    {
        // TODO: implement export logic
        ;
    }

    [Fact]
    public void ExportStatement_ReturnsPdfDocument()
    {
        // TODO: implement export logic
        ;
    }

    [Fact]
    public void ExportStatement_ReturnsXlsxArchive()
    {
        // TODO: implement export logic
        ;
    }

    [Fact]
    public void ExportReceipt_ReturnsPdfReceiptNamedForTransaction()
    {
        // TODO: implement export logic
        ;
    }

    private static List<TransactionHistoryItemDto> CreateTransactions()
    {
        // TODO: implement create transactions logic
        return default !;
    }
}