using Heaven.Models;
using Heaven.Repositories;

namespace Heaven.Services
{
    public class AccountService
    {
        private readonly AccountRepository _repository;

        public AccountService()
        {
            _repository = new AccountRepository();
        }

        public void CreateUser(User user)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            user.CreatedAt = DateTime.Now;
            user.IsHost = 0;

            _repository.Insert(user);
        }
    }
}