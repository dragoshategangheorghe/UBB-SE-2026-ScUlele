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
        TransactionExportService service = new ();

        var result = service.ExportStatement(CreateTransactions(), new TransactionHistoryRequest(), TransactionExportFormats.Csv);
        string content = Encoding.UTF8.GetString(result.Content);

        Assert.Equal("text/csv", result.ContentType);
        Assert.Contains("Reference Number", content);
        Assert.Contains("REF-100", content);
    }

    [Fact]
    public void ExportStatement_ReturnsPdfDocument()
    {
        TransactionExportService service = new ();

        var result = service.ExportStatement(CreateTransactions(), new TransactionHistoryRequest(), TransactionExportFormats.Pdf);

        Assert.Equal("application/pdf", result.ContentType);
        Assert.StartsWith("%PDF", Encoding.ASCII.GetString(result.Content));
    }

    [Fact]
    public void ExportStatement_ReturnsXlsxArchive()
    {
        TransactionExportService service = new ();

        var result = service.ExportStatement(CreateTransactions(), new TransactionHistoryRequest(), TransactionExportFormats.Xlsx);

        using MemoryStream memoryStream = new (result.Content);
        using ZipArchive archive = new (memoryStream, ZipArchiveMode.Read);

        Assert.Equal("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", result.ContentType);
        Assert.Contains(archive.Entries, entry => entry.FullName == "xl/worksheets/sheet1.xml");
    }

    [Fact]
    public void ExportReceipt_ReturnsPdfReceiptNamedForTransaction()
    {
        TransactionExportService service = new ();

        TransactionExportResult result = service.ExportReceipt(CreateTransactions()[0]);

        Assert.Equal("application/pdf", result.ContentType);
        Assert.Equal("transaction-receipt-100.pdf", result.FileName);
        Assert.StartsWith("%PDF", Encoding.ASCII.GetString(result.Content));
    }

    private static List<TransactionHistoryItemDto> CreateTransactions()
    {
        return new List<TransactionHistoryItemDto>
        {
            new ()
            {
                Id = 100,
                ReferenceNumber = "REF-100",
                Timestamp = new DateTime(2026, 3, 25, 14, 0, 0),
                TransactionType = "CardPayment",
                CounterpartyOrMerchant = "Coffee Shop",
                Amount = 12.5m,
                Currency = "EUR",
                Direction = "Debit",
                RunningBalanceAfterTransaction = 320m,
                Status = "Completed",
                SourceAccountIban = "RO49AAAA1B31007593840000",
                DestinationAccountIban = "RO49BBBB1B31007593840001",
                Fee = 0m
            }
        };
    }
}
