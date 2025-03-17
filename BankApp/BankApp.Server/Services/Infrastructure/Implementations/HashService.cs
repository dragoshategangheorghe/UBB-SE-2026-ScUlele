using BankApp.Server.Services.Infrastructure.Interfaces;

namespace BankApp.Server.Services.Infrastructure.Implementations
{
    public class HashService : IHashService
    {
        public string GetHash(string input)
        {
            // TODO: load hash
            return default !;
        }

        public bool Verify(string input, string hash)
        {
            // TODO: implement verify logic
            return default !;
        }
    }
}