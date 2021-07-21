using System;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.Exceptions;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using ApplicationCore.Entities;
namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public async Task<UserResponseModel> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var userResponseModel = new UserResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth
            };
            return userResponseModel;
        }

        public async Task<UserLoginResponseModel> Login(string email, string password)
        {
            var dbUser = await _userRepository.GetUserByEmail(email);
            if (dbUser == null)
            {
                throw new NotFoundException("email does not exists, please register first");
            }
            var hashedPassword = HashPassword(password, dbUser.Salt);
            if (hashedPassword == dbUser.HashedPassword)
            {
                var userLoginResponse = new UserLoginResponseModel
                {
                    Id = dbUser.Id,
                    Email = dbUser.Email,
                    FirstName = dbUser.FirstName,
                    DateOfBirth = dbUser.DateOfBirth,
                    LastName = dbUser.LastName
                };
                return userLoginResponse;
            }
            return null;

        }


            public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel requestModel)
        {
            //make sure email does not in DB
            var dbUser = await _userRepository.GetUserByEmail(requestModel.Email);

            if (dbUser != null)
            {
                throw new ConflictException("Email already exist");
            }
            //create a unique salt
            var salt = CreateSalt();
            var hashedPassword = HashPassword(requestModel.Password, salt);
            var user = new User
            {
                Email = requestModel.Email,
                Salt = salt,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                HashedPassword = hashedPassword
            };
            //save to DB by calling userRepository add method
            var createdUser = await _userRepository.AddAsync(user);
            var userResponse = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName
            };
            return userResponse;
        }

        private string CreateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }
        private string HashPassword(string password, string salt)
        {
            // Aarogon
            // Pbkdf2
            // BCrypt
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                                                    password: password,
                                                                    salt: Convert.FromBase64String(salt),
                                                                    prf: KeyDerivationPrf.HMACSHA512,
                                                                    iterationCount: 10000,
                                                                    numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
