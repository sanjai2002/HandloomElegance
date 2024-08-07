using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Core.IServices;
using HandloomElegance.Data.IRepository;
using HandloomElegance.Common.Utils;

namespace HandloomElegance.Core.Services
{
    public class userServices : IUserServices
    {
        private readonly IUserRepository _IUserRepository;
        public userServices(IUserRepository IUserRepository)
        {
            _IUserRepository = IUserRepository;

        }

        public async Task<bool> UserRegister(UserRegisterViewModel Register)
        {
            bool isEmailExists = _IUserRepository.FindEmailid(Register!.Email!);
            if (!isEmailExists)
            {
                User user = new User()
                {
                    UserId = Guid.NewGuid(),
                    Email = Register!.Email!,
                    Username = Register!.Email!.Split("@")[0],
                    PasswordHash = SHA256Encrypt.ComputePasswordToSha256Hash(Register!.Password!),
                    FirstName = Register.FirstName,
                    LastName = Register.LastName,
                    PhoneNumber = Register.PhoneNumber,
                    Role = "user",
                    CreatedAt = DateTime.Now,
                };
                await _IUserRepository.UserRegister(user);
                return true;
            }

            else
            {
                return false;
            }

        }
   
        public async Task<ReturnMsg>Userlogin(UserLoginViewModel Login)
        {
            // Check if the email exists in the repository
            bool loginExists = _IUserRepository.FindEmailid(Login!.Email!);
            if (loginExists)
            {
                var existingUser = _IUserRepository.GetUserDetails(Login!.Email!);
                // Check if the password matches
                if (existingUser.PasswordHash == SHA256Encrypt.ComputePasswordToSha256Hash(Login!.Password!))
                {
                    
                    ReturnMsg successMsg = new ReturnMsg()
                    {
                        Email = true,
                        Password = true,
                        Role = existingUser.Role,
                        // Token="dddd"
                    };
                    return successMsg;
                }
                else 
                {
                    ReturnMsg wrongPasswordMsg = new ReturnMsg()
                    {
                        Email = true,
                        Password = false
                    };
                    return wrongPasswordMsg;
                }
            }
            else
            {
                ReturnMsg userNotFoundMsg = new ReturnMsg()
                {
                    Email = false,
                    Password = false
                };
                return userNotFoundMsg;
            }
        }




    }

}