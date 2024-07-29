using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;

namespace HandloomElegance.Data.IRepository{
    public interface IUserRepository{

        public bool FindEmailid(string Email);
        public Task UserRegister(User User);
        
        

    }

}