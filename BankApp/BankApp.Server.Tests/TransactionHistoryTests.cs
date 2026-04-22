using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Models.DTOs.Transactions;
using BankApp.Models.Entities;
using BankApp.Server.Configuration;
using BankApp.Server.Repositories.Interfaces;
using BankApp.Server.Services.Implementations;
using BankApp.Server.Services.Infrastructure.Interfaces;
using BankApp.Server.Services.Interfaces;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;

namespace BankApp.Server.Tests
{
    [TestFixture]
    public class TransactionHistoryTests
    {
        private ITransactionHistoryRepository mockTransactionHistoryRepository;

        private ITransactionExportService mockTransactionExportService;
        private TransactionHistoryService transactionHistoryService;

        [SetUp]
        public void SetUp()
        {
            mockTransactionHistoryRepository = Substitute.For<ITransactionHistoryRepository>();
            mockTransactionExportService = Substitute.For<ITransactionExportService>();

            transactionHistoryService = new TransactionHistoryService(
                mockTransactionHistoryRepository, mockTransactionExportService);
        }

        [Test]
        public void GetHistory_UserExists_ReturnsUserHistory()
        {
            User user = CardServiceTests.CreateUser(false);
            mockTransactionHistoryRepository.GetTransactionsByUserId(user.Id).Returns([]);

            TransactionHistoryResponse transactionHistoryResponse = transactionHistoryService.GetHistory(user.Id, new TransactionHistoryRequest());

            Assert.That(transactionHistoryResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(transactionHistoryResponse.Success, Is.True);
                Assert.That(transactionHistoryResponse.Message, Is.EqualTo("Transaction history loaded successfully."));
            }
        }

        [Test]
        public void GetTransaction_TransactionDoesNotExist_ReturnsFailure()
        {
            User user = CardServiceTests.CreateUser(false);
            mockTransactionHistoryRepository.GetTransactionById(user.Id, 1).Returns((TransactionHistoryItemDto)null!);

            TransactionDetailsResponse transactionDetailsResponse = transactionHistoryService.GetTransaction(user.Id, 1);

            Assert.That(transactionDetailsResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(transactionDetailsResponse.Success, Is.False);
                Assert.That(transactionDetailsResponse.Message, Is.EqualTo("Transaction not found."));
            }
        }
        [Test]
        public void GetTransaction_TransactionExists_ReturnsDetails()
        {
            User user = CardServiceTests.CreateUser(false);
            TransactionHistoryItemDto transaction = new TransactionHistoryItemDto();
            transaction.Id = 1;
            mockTransactionHistoryRepository.GetTransactionById(user.Id, transaction.Id).Returns(transaction);

            TransactionDetailsResponse transactionDetailsResponse = transactionHistoryService.GetTransaction(user.Id, transaction.Id);

            Assert.That(transactionDetailsResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(transactionDetailsResponse.Success, Is.True);
                Assert.That(transactionDetailsResponse.Message, Is.EqualTo("Transaction details loaded successfully."));
                Assert.That(transactionDetailsResponse.Transaction, Is.EqualTo(transaction));
            }
        }

        [Test]
        public void ExportReceipt_TransactionDoesNotExist_ReturnsNewTransactionExportResult()
        {
            User user = CardServiceTests.CreateUser(false);
            TransactionHistoryItemDto transaction = new TransactionHistoryItemDto();
            transaction.Id = 1;
            mockTransactionHistoryRepository.GetTransactionById(user.Id, transaction.Id).Returns((TransactionHistoryItemDto)null!);

            TransactionExportResult transactionExportResult = transactionHistoryService.ExportReceipt(user.Id, transaction.Id);

            Assert.That(transactionExportResult, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(transactionExportResult.ContentType, Is.EqualTo(string.Empty));
                Assert.That(transactionExportResult.FileName, Is.EqualTo(string.Empty));
                Assert.That(transactionExportResult.Content, Is.EqualTo(Array.Empty<byte>()));
            }
        }
        [Test]
        public void ExportReceipt_TransactionExists_ReturnsExistingTransactionExportResult()
        {
            User user = CardServiceTests.CreateUser(false);
            TransactionHistoryItemDto transaction = new TransactionHistoryItemDto();
            transaction.Id = 1;
            mockTransactionHistoryRepository.GetTransactionById(user.Id, transaction.Id).Returns(transaction);
            mockTransactionExportService.ExportReceipt(transaction)
                .Returns(new TransactionExportResult { FileName = "Exists.txt" });
            TransactionExportResult transactionExportResult = transactionHistoryService.ExportReceipt(user.Id, transaction.Id);

            Assert.That(transactionExportResult, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(transactionExportResult.FileName, Is.EqualTo("Exists.txt"));
            }
        }
    }
}
