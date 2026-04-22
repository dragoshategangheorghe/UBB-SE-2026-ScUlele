using BankApp.Server.Repositories.Interfaces;
using BankApp.Server.Services.Implementations;
using BankApp.Server.Services.Infrastructure.Interfaces;
using Moq;
using Xunit;
using BankApp.Models.DTOs.Auth;
using BankApp.Models.Entities;

namespace BankApp.Server.Tests
{
    public class AuthServiceTests
    {
        private static AuthService CreateService(
        Mock<IAuthRepository> authRepositoryMock,
        Mock<IHashService> hashServiceMock,
        Mock<IJWTService> jwtServiceMock,
        Mock<IOTPService> otpServiceMock,
        Mock<IEmailService> emailServiceMock)
        {
            return new AuthService(
            authRepositoryMock.Object,
            hashServiceMock.Object,
            jwtServiceMock.Object,
            otpServiceMock.Object,
            emailServiceMock.Object);
        }
        private static User CreateUser(bool isTwoFactorEnabled = false, bool isLocked = false, int failedLoginAttempts = 0)
        {
            return new User
            {
                Id = 1,
                Email = "test@test.com",
                PasswordHash = "hashedPassword",
                FullName = "Test Test",
                Is2FAEnabled = isTwoFactorEnabled,
                IsLocked = isLocked,
                FailedLoginAttempts = failedLoginAttempts,
                Preferred2FAMethod = "email"
            };
        }
        [Fact]
        public void LoginFailInvalidFormat()
        {
            Mock<IAuthRepository> authRepoMock = new ();
            Mock<IHashService> hashMock = new ();
            Mock<IJWTService> jwtMock = new ();
            Mock<IOTPService> otpMock = new ();
            Mock<IEmailService> emailMock = new ();

            AuthService service = CreateService(authRepoMock, hashMock, jwtMock, otpMock, emailMock);

            LoginRequest request = new LoginRequest
            {
                Email = "invalidemail",
                Password = "imvalidpassword"
            };

            LoginResponse response = service.Login(request);

            Assert.False(response.Success);
            Assert.Equal("Invalid mail format.", response.Error);
            authRepoMock.Verify(repo => repo.FindUserByEmail(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void LoginFailUserNotFound()
        {
            Mock<IAuthRepository> authRepoMock = new ();
            Mock<IHashService> hashMock = new ();
            Mock<IJWTService> jwtMock = new ();
            Mock<IOTPService> otpMock = new ();
            Mock<IEmailService> emailMock = new ();

            AuthService service = CreateService(authRepoMock, hashMock, jwtMock, otpMock, emailMock);

            LoginRequest request = new LoginRequest
            {
                Email = "test@example.com",
                Password = "Password.3"
            };

            LoginResponse response = service.Login(request);

            Assert.False(response.Success);
            Assert.Equal("Invalid email or password.", response.Error);
        }
        [Fact]
        public void LoginFailAndIncrementsFailedAttemptsWhenPasswordIncorrect()
        {
            Mock<IAuthRepository> authRepoMock = new ();
            Mock<IHashService> hashMock = new ();
            Mock<IJWTService> jwtMock = new ();
            Mock<IOTPService> otpMock = new ();
            Mock<IEmailService> emailMock = new ();
            User user = CreateUser(failedLoginAttempts: 0);

            authRepoMock.Setup(repo => repo.FindUserByEmail(user.Email)).Returns(user);
            hashMock.Setup(hash => hash.Verify("wrongPassword", user.PasswordHash)).Returns(false);

            AuthService service = CreateService(authRepoMock, hashMock, jwtMock, otpMock, emailMock);

            LoginRequest request = new LoginRequest
            {
                Email = user.Email,
                Password = "wrongPassword"
            };

            LoginResponse response = service.Login(request);

            Assert.False(response.Success);
            Assert.Equal("Invalid email or password.", response.Error);
            authRepoMock.Verify(repo => repo.IncrementFailedAttempts(user.Id), Times.Once);
        }
        [Fact]
        public void LoginLocksAccountWhenMaxFailedAttempts()
        {
            Mock<IAuthRepository> authRepoMock = new ();
            Mock<IHashService> hashMock = new ();
            Mock<IJWTService> jwtMock = new ();
            Mock<IOTPService> otpMock = new ();
            Mock<IEmailService> emailMock = new ();
            User user = CreateUser(failedLoginAttempts: 4);

            authRepoMock.Setup(repo => repo.FindUserByEmail(user.Email)).Returns(user);
            hashMock.Setup(hash => hash.Verify("wrongPassword", user.PasswordHash)).Returns(false);

            AuthService service = CreateService(authRepoMock, hashMock, jwtMock, otpMock, emailMock);

            LoginRequest request = new LoginRequest
            {
                Email = user.Email,
                Password = "wrongPassword"
            };

            LoginResponse response = service.Login(request);

            Assert.False(response.Success);
            Assert.Equal("Account locked due to too many failed attempts.", response.Error);
            authRepoMock.Verify(repo => repo.LockAccount(user.Id, It.IsAny<DateTime>()), Times.Once);
            emailMock.Verify(email => email.SendLockNotification(user.Email), Times.Once);
        }

            [Fact]
            public void LoginSuccessAndTokenWhenLoginIsCorrectAndNo2FA()
            {
                Mock<IAuthRepository> authRepoMock = new ();
                Mock<IHashService> hashMock = new ();
                Mock<IJWTService> jwtMock = new ();
                Mock<IOTPService> otpMock = new ();
                Mock<IEmailService> emailMock = new ();
                User user = CreateUser(isTwoFactorEnabled: false);
                string expectedToken = "fake-jwt-token";

                authRepoMock.Setup(repo => repo.FindUserByEmail(user.Email)).Returns(user);
                hashMock.Setup(hash => hash.Verify("correctPassword", user.PasswordHash)).Returns(true);
                jwtMock.Setup(jwt => jwt.GenerateToken(user.Id)).Returns(expectedToken);

                AuthService service = CreateService(authRepoMock, hashMock, jwtMock, otpMock, emailMock);

                LoginRequest request = new LoginRequest
                {
                    Email = user.Email,
                    Password = "correctPassword"
                };
                LoginResponse response = service.Login(request);

                Assert.True(response.Success);
                Assert.Equal(expectedToken, response.Token);
                Assert.False(response.Requires2FA);
                Assert.Equal(user.Id, response.UserId);
                authRepoMock.Verify(repo => repo.ResetFailedAttempts(user.Id), Times.Once);
                authRepoMock.Verify(repo => repo.CreateSession(user.Id, expectedToken, null, null, null), Times.Once);
                emailMock.Verify(email => email.SendLoginAlert(user.Email), Times.Once);
            }

            [Fact]
            public void LoginRequires2FAWhenLoginIsCorrectAnd2FAEnabled()
            {
                Mock<IAuthRepository> authRepoMock = new ();
                Mock<IHashService> hashMock = new ();
                Mock<IJWTService> jwtMock = new ();
                Mock<IOTPService> otpMock = new ();
                Mock<IEmailService> emailMock = new ();
                User user = CreateUser(isTwoFactorEnabled: true);
                string expectedOtp = "123456";

                authRepoMock.Setup(repo => repo.FindUserByEmail(user.Email)).Returns(user);
                hashMock.Setup(hash => hash.Verify("correctPassword", user.PasswordHash)).Returns(true);
                otpMock.Setup(otp => otp.GenerateTOTP(user.Id)).Returns(expectedOtp);

                AuthService service = CreateService(authRepoMock, hashMock, jwtMock, otpMock, emailMock);

                LoginRequest request = new LoginRequest
                {
                    Email = user.Email,
                    Password = "correctPassword"
                };
                LoginResponse response = service.Login(request);

                Assert.True(response.Success);
                Assert.True(response.Requires2FA);
                Assert.Null(response.Token);
                Assert.Equal(user.Id, response.UserId);
                emailMock.Verify(email => email.SendOTPCode(user.Email, expectedOtp), Times.Once);
            }

            [Fact]
            public void VerifyOTPReturnsSuccessAndTokenWhenOTPIsValid()
            {
                Mock<IAuthRepository> authRepoMock = new ();
                Mock<IHashService> hashMock = new ();
                Mock<IJWTService> jwtMock = new ();
                Mock<IOTPService> otpMock = new ();
                Mock<IEmailService> emailMock = new ();
                User user = CreateUser();
                string expectedToken = "fake-jwt-token";

                authRepoMock.Setup(repo => repo.FindUserById(user.Id)).Returns(user);
                otpMock.Setup(otp => otp.VerifyTOTP(user.Id, "123456")).Returns(true);
                jwtMock.Setup(jwt => jwt.GenerateToken(user.Id)).Returns(expectedToken);

                AuthService service = CreateService(authRepoMock, hashMock, jwtMock, otpMock, emailMock);

                VerifyOTPRequest request = new VerifyOTPRequest
                {
                    UserId = user.Id,
                    OTPCode = "123456"
                };

                LoginResponse response = service.VerifyOTP(request);

                Assert.True(response.Success);
                Assert.Equal(expectedToken, response.Token);
                otpMock.Verify(otp => otp.InvalidateOTP(user.Id), Times.Once);
                authRepoMock.Verify(repo => repo.CreateSession(user.Id, expectedToken, null, null, null), Times.Once);
            }

            [Fact]
            public void RegisterSuccessWhenDataValid()
            {
                Mock<IAuthRepository> authRepoMock = new ();
                Mock<IHashService> hashMock = new ();
                Mock<IJWTService> jwtMock = new ();
                Mock<IOTPService> otpMock = new ();
                Mock<IEmailService> emailMock = new ();
                authRepoMock.Setup(repo => repo.CreateUser(It.IsAny<User>())).Returns(true);
                hashMock.Setup(hash => hash.GetHash(It.IsAny<string>())).Returns("hashedPassword");

                AuthService service = CreateService(authRepoMock, hashMock, jwtMock, otpMock, emailMock);

                RegisterRequest request = new RegisterRequest
                {
                    Email = "newuser@test.com",
                    Password = "ValidPassword123!",
                    FullName = "New User"
                };

                RegisterResponse response = service.Register(request);

                Assert.True(response.Success);
                Assert.Null(response.Error);
                authRepoMock.Verify(repo => repo.CreateUser(It.IsAny<User>()), Times.Once);
            }

            [Fact]
            public void LogoutReturnsTrueWhenSessionExists()
            {
                Mock<IAuthRepository> authRepoMock = new ();
                Mock<IHashService> hashMock = new ();
                Mock<IJWTService> jwtMock = new ();
                Mock<IOTPService> otpMock = new ();
                Mock<IEmailService> emailMock = new ();
                Session session = new Session { Id = 1, UserId = 1, Token = "valid-token" };
                authRepoMock.Setup(repo => repo.FindSessionByToken("valid-token")).Returns(session);

                AuthService service = CreateService(authRepoMock, hashMock, jwtMock, otpMock, emailMock);

                bool result = service.Logout("valid-token");

                Assert.True(result);
                authRepoMock.Verify(repo => repo.UpdateSessionToken(session.Id), Times.Once);
            }
        [Fact]
        public void RegisterErrorWhenEmailIsInvalid()
        {
            Mock<IAuthRepository> authRepoMock = new ();
            Mock<IHashService> hashMock = new ();
            Mock<IJWTService> jwtMock = new ();
            Mock<IOTPService> otpMock = new ();
            Mock<IEmailService> emailMock = new ();
            AuthService service = CreateService(authRepoMock, hashMock, jwtMock, otpMock, emailMock);

            RegisterRequest request = new RegisterRequest
            {
                Email = "invalid-email",
                Password = "ValidPassword123!",
                FullName = "New User"
            };

            RegisterResponse response = service.Register(request);

            Assert.False(response.Success);
            Assert.Equal("Invalid email format.", response.Error);
            authRepoMock.Verify(repo => repo.FindUserByEmail(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void RegisterErrorWhenPasswordIsWeak()
        {
            Mock<IAuthRepository> authRepoMock = new ();
            Mock<IHashService> hashMock = new ();
            Mock<IJWTService> jwtMock = new ();
            Mock<IOTPService> otpMock = new ();
            Mock<IEmailService> emailMock = new ();
            AuthService service = CreateService(authRepoMock, hashMock, jwtMock, otpMock, emailMock);

            RegisterRequest request = new RegisterRequest
            {
                Email = "newuser@test.com",
                Password = "weak",
                FullName = "New User"
            };

            RegisterResponse response = service.Register(request);

            Assert.False(response.Success);
            Assert.Equal("Password must be at least 8 characters with uppercase, lowercase, and a digit.", response.Error);
            authRepoMock.Verify(repo => repo.FindUserByEmail(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void RegisterErrorWhenFullNameMissing()
        {
            Mock<IAuthRepository> authRepoMock = new ();
            Mock<IHashService> hashMock = new ();
            Mock<IJWTService> jwtMock = new ();
            Mock<IOTPService> otpMock = new ();
            Mock<IEmailService> emailMock = new ();
            AuthService service = CreateService(authRepoMock, hashMock, jwtMock, otpMock, emailMock);

            RegisterRequest request = new RegisterRequest
            {
                Email = "newuser@test.com",
                Password = "ValidPassword123!",
                FullName = " "
            };

            RegisterResponse response = service.Register(request);

            Assert.False(response.Success);
            Assert.Equal("Full name is required.", response.Error);
            authRepoMock.Verify(repo => repo.FindUserByEmail(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void RegisterErrorWhenEmailAlreadyRegistered()
        {
            Mock<IAuthRepository> authRepoMock = new ();
            Mock<IHashService> hashMock = new ();
            Mock<IJWTService> jwtMock = new ();
            Mock<IOTPService> otpMock = new ();
            Mock<IEmailService> emailMock = new ();
            User existingUser = CreateUser();

            authRepoMock.Setup(repo => repo.FindUserByEmail(existingUser.Email)).Returns(existingUser);

            AuthService service = CreateService(authRepoMock, hashMock, jwtMock, otpMock, emailMock);

            RegisterRequest request = new RegisterRequest
            {
                Email = existingUser.Email,
                Password = "ValidPassword123!",
                FullName = "New User"
            };

            RegisterResponse response = service.Register(request);

            Assert.False(response.Success);
            Assert.Equal("Email is already registered.", response.Error);
            authRepoMock.Verify(repo => repo.CreateUser(It.IsAny<User>()), Times.Never);
        }

        [Fact]
        public void RegisterErrorWhenDatabaseCreationFails()
        {
            Mock<IAuthRepository> authRepoMock = new ();
            Mock<IHashService> hashMock = new ();
            Mock<IJWTService> jwtMock = new ();
            Mock<IOTPService> otpMock = new ();
            Mock<IEmailService> emailMock = new ();
            authRepoMock.Setup(repo => repo.CreateUser(It.IsAny<User>())).Returns(false);

            AuthService service = CreateService(authRepoMock, hashMock, jwtMock, otpMock, emailMock);

            RegisterRequest request = new RegisterRequest
            {
                Email = "newuser@test.com",
                Password = "ValidPassword123!",
                FullName = "New User"
            };

            RegisterResponse response = service.Register(request);

            Assert.False(response.Success);
            Assert.Equal("Failed to create account.", response.Error);
        }
    }
    }