using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
using Microsoft.VisualBasic;

namespace HandloomElegance.Data.IRepository{
    public interface IUserRepository{

        public bool FindEmailid(string Email);
        public  User GetUserDetails(string Email);

        public Task UserRegister(User User);


        
        

    }

}