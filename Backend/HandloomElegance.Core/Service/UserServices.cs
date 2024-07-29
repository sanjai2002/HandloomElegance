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
            bool isEmailExists= _IUserRepository.FindEmailid(Register!.Email!);
            if(!isEmailExists){
             User user=new User(){
                UserId=Guid.NewGuid(),
                Username=Register!.Username!,
                Email=Register!.Email!,
                PasswordHash=SHA256Encrypt.ComputePasswordToSha256Hash(Register!.Password!),
                FirstName=Register.FirstName,
                LastName=Register.LastName,
                PhoneNumber=Register.PhoneNumber,
                Role="user",
                CreatedAt=DateTime.Now,
            };
            await _IUserRepository.UserRegister(user);
            return true;
            }

            else{
                return false;
            }

        }



    }

}