using HandloomElegance.Common.ViewModels;
using HandloomElegance.Common.Utils;

namespace HandloomElegance.Core.IServices{
    public interface IUserServices{
        public Task<bool>UserRegister(UserRegisterViewModel Register);
        public Task<ReturnMsg>Userlogin(UserLoginViewModel Login);

    

    }
}