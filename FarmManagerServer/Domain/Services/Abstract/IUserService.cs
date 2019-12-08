using Domain.Dtos;
using Domain.Entities;
using Shared.Models;

namespace Domain.Services.Abstract
{
    public interface IUserService
    {
        UserRegistrationDto Register(UserRegistrationDto user);
        void ForgetPassword(EntityHolder<UserForgetPasswordDto> entityHolder);
        void ChangePassword(UserChangePassword user);
        bool CanChangePassword(string token);
        User GetValidUser(string username, string password);
        User GetValidUser(string username);
    }
}
