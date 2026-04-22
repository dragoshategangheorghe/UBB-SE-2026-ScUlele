using BankApp.Models.DTOs.Profile;
using BankApp.Models.Entities;
using BankApp.Models.Enums;
using BankApp.Server.Repositories.Interfaces;
using BankApp.Server.Services.Implementations;
using BankApp.Server.Services.Infrastructure.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace BankApp.Server.Tests
{
    [TestFixture]

    public class ProfileServiceTests
    {
        private IUserRepository mockUserRepository;
        private IHashService mockHashService;

        private ProfileService profileService;

        [SetUp]
        public void Setup()
        {
            mockUserRepository = Substitute.For<IUserRepository>();
            mockHashService = Substitute.For<IHashService>();

            profileService = new ProfileService(mockUserRepository, mockHashService);
        }

        [Test]
        public void GetUserById_UserIdNull_ReturnsNull()
        {
            User? user = profileService.GetUserById(0);
            Assert.That(user, Is.Null);
        }

        [Test]
        public void GetUserById_MockUser_ReturnsUser()
        {
            User mockUser = new User { Id = 1, FullName = "John Doe" };
            mockUserRepository.FindById(1).Returns(mockUser);
            User? user = profileService.GetUserById(1);
            Assert.That(user, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(user.Id, Is.EqualTo(1));
                Assert.That(user.FullName, Is.EqualTo("John Doe"));
            }
        }

        [Test]
        public void LinkOAuth_ReturnsException()
        {
            Assert.Throws<NotImplementedException>(() => profileService.LinkOAuth(1, "Google"));
        }

        [Test]
        public void UnlinkOAuth_ReturnsException()
        {
            Assert.Throws<NotImplementedException>(() => profileService.UnlinkOAuth(1, "Google"));
        }

        [Test]
        public void UpdatePersonalInfo_UserIdNull_ReturnsFailure()
        {
            UpdateProfileResponse updateProfileResponse =
                profileService.UpdatePersonalInfo(new UpdateProfileRequest());
            Assert.That(updateProfileResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(updateProfileResponse.Success, Is.False);
                Assert.That(updateProfileResponse.Message, Is.EqualTo("Something went wrong. Please try again."));
            }

            // Assert.Pass();
        }

        [Test]
        public void UpdatePersonalInfo_UserNotFound_ReturnsFailure()
        {
            mockUserRepository.FindById(Arg.Any<int>()).Returns((User?)null);
            UpdateProfileResponse updateProfileResponse =
                profileService.UpdatePersonalInfo(new UpdateProfileRequest { UserId = 1 });
            Assert.That(updateProfileResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(updateProfileResponse.Success, Is.False);
                Assert.That(updateProfileResponse.Message, Is.EqualTo("User not found."));
            }
        }

        [Test]
        public void UpdatePersonalInfo_InvalidPhoneNumber_ReturnsFailure()
        {
            User user = new User { Id = 1, PhoneNumber = "1234567890" };
            mockUserRepository.FindById(1).Returns(user);
            UpdateProfileResponse updateProfileResponse =
                profileService.UpdatePersonalInfo(new UpdateProfileRequest { UserId = 1, PhoneNumber = "invalid-phone" });
            Assert.That(updateProfileResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(updateProfileResponse.Success, Is.False);
                Assert.That(updateProfileResponse.Message, Is.EqualTo("Invalid phone number."));
            }
        }

        [Test]
        public void UpdatePersonalInfo_UserRepositoryError_ReturnsFailure()
        {
            User user = new User { Id = 1, PhoneNumber = "1234567890", Address = "Old Address" };
            mockUserRepository.FindById(1).Returns(user);
            mockUserRepository.UpdateUser(user).Returns(false);

            UpdateProfileResponse updateProfileResponse =
                profileService.UpdatePersonalInfo(new UpdateProfileRequest { UserId = 1, PhoneNumber = "0987654321", Address = "New Address" });

            Assert.That(updateProfileResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(updateProfileResponse.Success, Is.False);
                Assert.That(updateProfileResponse.Message, Is.EqualTo("Could not update user."));
            }
        }

        [Test]
        public void UpdatePersonalInfo_ValidRequest_ReturnsSuccess()
        {
            User user = new User { Id = 1, PhoneNumber = "1234567890", Address = "Old Address" };
            mockUserRepository.FindById(1).Returns(user);
            mockUserRepository.UpdateUser(user).Returns(true);
            UpdateProfileResponse updateProfileResponse =
                profileService.UpdatePersonalInfo(new UpdateProfileRequest { UserId = 1, PhoneNumber = "0987654321", Address = "New Address" });
            Assert.That(updateProfileResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(updateProfileResponse.Success, Is.True);
                Assert.That(updateProfileResponse.Message, Is.EqualTo("User profile updated successfully."));
                Assert.That(user.PhoneNumber, Is.EqualTo("0987654321"));
                Assert.That(user.Address, Is.EqualTo("New Address"));
                mockUserRepository.Received(1).UpdateUser(user);
            }
        }

        [Test]

        public void ChangePassword_UserIdNull_ReturnsFailure()
        {
            ChangePasswordResponse changePasswordResponse =
                profileService.ChangePassword(new ChangePasswordRequest());
            Assert.That(changePasswordResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(changePasswordResponse.Success, Is.False);
                Assert.That(changePasswordResponse.Message, Is.EqualTo("User not found."));
            }
        }

        [Test]

        public void ChangePassword_IncorrectCurrentPassword_ReturnsFailure()
        {
            User user = new User { Id = 1, PasswordHash = "hashed-password" };
            mockUserRepository.FindById(1).Returns(user);
            mockHashService.Verify("wrong-password", "hashed-password").Returns(false);
            ChangePasswordResponse changePasswordResponse =
                profileService.ChangePassword(new ChangePasswordRequest { UserId = 1, CurrentPassword = "wrong-password", NewPassword = "NewStrongP@ssw0rd" });
            Assert.That(changePasswordResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(changePasswordResponse.Success, Is.False);
                Assert.That(changePasswordResponse.Message, Is.EqualTo("Current password is incorrect. Please try again."));
            }
        }

        [Test]
        public void ChangePassword_CorrectCurrentPassword_ReturnsSuccess()
        {
            User user = new User { Id = 1, PasswordHash = "hashed-password" };
            mockUserRepository.FindById(1).Returns(user);
            mockHashService.Verify("correct-password", "hashed-password").Returns(true);
            mockHashService.GetHash("NewStrongP@ssw0rd").Returns("new-hashed-password");
            ChangePasswordResponse changePasswordResponse =
                profileService.ChangePassword(new ChangePasswordRequest { UserId = 1, CurrentPassword = "correct-password", NewPassword = "NewStrongP@ssw0rd" });
            Assert.That(changePasswordResponse, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(changePasswordResponse.Success, Is.True);
                Assert.That(changePasswordResponse.Message, Is.EqualTo("Password changed successfully."));
                Assert.That(user.PasswordHash, Is.EqualTo("new-hashed-password"));
                mockUserRepository.Received(1).UpdatePassword(1, "new-hashed-password");
            }
        }

        [Test]

        public void Enable2FA_UserIdNull_ReturnsFailure()
        {
            int userId = 1;
            mockUserRepository.FindById(userId).Returns((User?)null);
            bool twoFactorResponse = profileService.Enable2FA(1, new TwoFactorMethod());
            using (Assert.EnterMultipleScope())
            {
                Assert.That(twoFactorResponse, Is.False);
            }
        }

        [Test]

        public void Enable2FA_ValidRequest_ReturnsSuccess()
        {
            User user = CardServiceTests.CreateUser(true);
            mockUserRepository.FindById(user.Id).Returns(user);
            mockUserRepository.UpdateUser(user).Returns(true);
            TwoFactorMethod method = TwoFactorMethod.Email;
            bool twoFactorResponse = profileService.Enable2FA(user.Id, method);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(twoFactorResponse, Is.True);
                Assert.That(user.Is2FAEnabled, Is.True);
                Assert.That(user.Preferred2FAMethod, Is.EqualTo(TwoFactorMethod.Email.ToString()));
                mockUserRepository.Received(1).UpdateUser(user);
            }
        }

        [Test]
        public void Disable2FA_UserIdNull_ReturnsFailure()
        {
            int userId = 1;
            mockUserRepository.FindById(userId).Returns((User?)null);
            bool twoFactorResponse = profileService.Disable2FA(1);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(twoFactorResponse, Is.False);
            }
        }

        [Test]
        public void Disable2FA_ValidRequest_ReturnsSuccess()
        {
            User user = CardServiceTests.CreateUser(true);
            mockUserRepository.FindById(user.Id).Returns(user);
            mockUserRepository.UpdateUser(user).Returns(true);
            bool twoFactorResponse = profileService.Disable2FA(user.Id);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(twoFactorResponse, Is.True);
                Assert.That(user.Is2FAEnabled, Is.False);
                Assert.That(user.Preferred2FAMethod, Is.Null);
                mockUserRepository.Received(1).UpdateUser(user);
            }
        }

        [Test]
        public void GetOAuthLinks_UserIdNull_ReturnsEmptyList()
        {
            int userId = 1;
            mockUserRepository.FindById(userId).Returns((User?)null);
            List<OAuthLink> links = profileService.GetOAuthLinks(1);
            Assert.That(links, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(links, Is.Empty);
            }
        }

        [Test]
        public void GetOAuthLinks_ValidRequest_ReturnsLinks()
        {
            User user = CardServiceTests.CreateUser(true);
            List<OAuthLink> mockLinks = new List<OAuthLink>
            {
                new OAuthLink { Id = 1, Provider = "Google", ProviderUserId = "google-123" },
                new OAuthLink { Id = 2, Provider = "Facebook", ProviderUserId = "fb-456" }
            };
            mockUserRepository.FindById(user.Id).Returns(user);
            mockUserRepository.GetLinkedProviders(user.Id).Returns(mockLinks);
            List<OAuthLink> links = profileService.GetOAuthLinks(user.Id);
            Assert.That(links, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(links.Count, Is.EqualTo(2));
                Assert.That(links[0].Provider, Is.EqualTo("Google"));
                Assert.That(links[0].ProviderUserId, Is.EqualTo("google-123"));
                Assert.That(links[1].Provider, Is.EqualTo("Facebook"));
                Assert.That(links[1].ProviderUserId, Is.EqualTo("fb-456"));
            }
        }

        [Test]
        public void GetNotificationPreferences_UserIdNull_ReturnsEmptyList()
        {
            int userId = 1;
            mockUserRepository.FindById(userId).Returns((User?)null);
            List<NotificationPreference> prefs = profileService.GetNotificationPreferences(1);
            Assert.That(prefs, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(prefs, Is.Empty);
            }
        }

        [Test]
        public void GetNotificationPreferences_ValidRequest_ReturnsPreferences()
        {
            User user = CardServiceTests.CreateUser(true);
            List<NotificationPreference> mockPrefs = new List<NotificationPreference>
            {
                new NotificationPreference { Id = 1, EmailEnabled = true },
                new NotificationPreference { Id = 2, SmsEnabled = false }
            };
            mockUserRepository.FindById(user.Id).Returns(user);
            mockUserRepository.GetNotificationPreferences(user.Id).Returns(mockPrefs);
            List<NotificationPreference> prefs = profileService.GetNotificationPreferences(user.Id);
            Assert.That(prefs, Is.Not.Null);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(prefs.Count, Is.EqualTo(2));
                Assert.That(prefs[0].EmailEnabled, Is.True);
                Assert.That(prefs[1].SmsEnabled, Is.False);
            }
        }

        [Test]
        public void UpdateNotificationPreferences_UserIdNull_ReturnsFailure()
        {
            int userId = 1;
            mockUserRepository.FindById(userId).Returns((User?)null);
            bool result = profileService.UpdateNotificationPreferences(1, new List<NotificationPreference>());
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.False);
            }
        }

        [Test]
        public void UpdateNotificationPreferences_ValidRequest_ReturnsSuccess()
        {
            User user = CardServiceTests.CreateUser(true);
            List<NotificationPreference> newPrefs = new List<NotificationPreference>
            {
                new NotificationPreference { Id = 1, EmailEnabled = false },
                new NotificationPreference { Id = 2, SmsEnabled = true }
            };
            mockUserRepository.FindById(user.Id).Returns(user);
            mockUserRepository.UpdateNotificationPreferences(user.Id, newPrefs).Returns(true);
            bool result = profileService.UpdateNotificationPreferences(user.Id, newPrefs);
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.True);
                mockUserRepository.Received(1).UpdateNotificationPreferences(user.Id, newPrefs);
            }
        }

        [Test]
        public void VerifyPassword_UserIdNull_ReturnsFalse()
        {
            int userId = 1;
            mockUserRepository.FindById(userId).Returns((User?)null);
            bool result = profileService.VerifyPassword(1, "any-password");
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.False);
            }
        }

        [Test]
        public void VerifyPassword_UserFound_ReturnsHashVerificationResult()
        {
            User user = new User { Id = 1, PasswordHash = "hashed-password" };
            mockUserRepository.FindById(1).Returns(user);
            mockHashService.Verify("input-password", "hashed-password").Returns(true);
            bool result = profileService.VerifyPassword(1, "input-password");
            using (Assert.EnterMultipleScope())
            {
                Assert.That(result, Is.True);
            }
        }
    }
}
