using System.Data.Entity;
using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Data.IRepository;
namespace HandloomElegance.Data.Repository{
    public class UserRepository:IUserRepository{
        private readonly HandloomEleganceDbContext _HandloomEleganceDbContext;
        public UserRepository(HandloomEleganceDbContext HandloomEleganceDbContext){
            _HandloomEleganceDbContext=HandloomEleganceDbContext;

        }
        public async Task UserRegister(User user){
           await _HandloomEleganceDbContext.Users.AddAsync(user);
           await _HandloomEleganceDbContext.SaveChangesAsync();
        }

        public bool FindEmailid(string Emailid){
            return  _HandloomEleganceDbContext.Users.Any(e=>e.Email==Emailid);
            
        }

        public User GetUserDetails(string Email){
            return  _HandloomEleganceDbContext.Users!.Where(e=>e.Email==Email).FirstOrDefault()!;

        }
  

    }

}
