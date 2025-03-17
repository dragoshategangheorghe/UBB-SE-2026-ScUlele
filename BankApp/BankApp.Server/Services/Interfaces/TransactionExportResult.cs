namespace BankApp.Server.Services.Interfaces
{
    public class TransactionExportResult
    {
        public byte[] Content { get; set; };
        public string ContentType { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
    }
}