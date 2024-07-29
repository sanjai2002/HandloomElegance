using HandloomElegance.Common.ViewModels;

namespace HandloomElegance.Core.IServices{
    public interface IUserServices{
        public Task<bool>UserRegister(UserRegisterViewModel Register);

    

    }
}