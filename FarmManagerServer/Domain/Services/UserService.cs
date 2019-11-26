using AutoMapper;
using Domain.Abstract;
using Domain.DAL;
using Domain.Dtos;
using Domain.Entities;
using Domain.Services.Abstract;
using Shared.Abstract;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        #region Properties

        private IEmailService _emailService;
        private readonly IMapper _mapper;

        #endregion
        #region Constructors

        public UserService(IEmailService emailService, IMapper mapper, IBaseRepository<User> mainRepository) : base(mainRepository)
        {
            _emailService = emailService;
            _mapper = mapper;
        }

        #endregion
        #region Methods

        public UserRegistrationDto Register(UserRegistrationDto user)
        {
            if (MainRepository.FindFirstOrDefault(x => x.Username == user.Username) != null)
            {
                throw new Exception("Username " + user.Username + " is already taken.");
            }

            if (MainRepository.FindFirstOrDefault(x => x.Email == user.Email) != null)
            {
                throw new Exception("Email " + user.Email + " is already taken.");
            }

            var userToInsert = _mapper.Map<User>(user);
            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

            userToInsert.PasswordHash = passwordHash;
            userToInsert.PasswordSalt = passwordSalt;
            MainRepository.Add(userToInsert);
            MainRepository.Save();

            // clear passwords
            user.Password = null;
            user.MatchPassword = null;

            return user;
        }

        public void ForgetPassword(EntityHolder<UserForgetPasswordDto> entityHolder)
        {
            var userFromDb = MainRepository.FindFirstOrDefault(x => x.Username == entityHolder.Entity.Username && x.Email == entityHolder.Entity.Email);

            if (userFromDb != null)
            {
                userFromDb.ResetPasswordTokenValid = DateTime.Now.AddHours(1);
                userFromDb.ResetPasswordToken = Guid.NewGuid().ToString("N").ToUpper();
                MainRepository.Update(userFromDb);
                MainRepository.Save();

                Mail mail = new Mail
                {
                    TemplateName = "forget-password.html",
                    MailTo = userFromDb.Email,
                    MailSubject = "Changing forgotten password",
                    Attributes = new Dictionary<string, object>
                    {
                        { "username", userFromDb.Username  },
                        { "passwordChangeLink", $"http://{entityHolder.BaseUrl}/change-password/{userFromDb.ResetPasswordToken}" }
                    }
                };

                _emailService.SendEmail(mail);
            }
            else
            {
                throw new Exception("Provided username and e-mail do not match.");
            }
        }

        public void ChangePassword(UserChangePassword user)
        {
            var userFromDb = MainRepository.FindFirstOrDefault(x => x.ResetPasswordToken == user.Token);

            CheckIfTokenIsValid(userFromDb);
            userFromDb.ResetPasswordTokenValid = DateTime.Now;
            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
            userFromDb.PasswordSalt = passwordSalt;
            userFromDb.PasswordHash = passwordHash;
            MainRepository.Update(userFromDb);
            MainRepository.Save();
        }

        public bool CanChangePassword(string token)
        {
            var userFromDb = MainRepository.FindFirstOrDefault(x => x.ResetPasswordToken == token);

            CheckIfTokenIsValid(userFromDb);

            return true;
        }

        public User GetValidUser(string username, string password)
        {
            var user = GetValidUser(username);

            return user != null && VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt) ? user : null;
        }

        public User GetValidUser(string username)
        {
            return MainRepository.FindFirstOrDefault(x => x.Username == username);
        }

        #endregion
        #region Private methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void CheckIfTokenIsValid(User user)
        {
            if (user == null || user.ResetPasswordTokenValid < DateTime.Now)
            {
                throw new Exception("Provided token is invalid or time it has expired.");
            }
        }

        #endregion
    }
}
