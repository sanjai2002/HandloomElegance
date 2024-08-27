using HandloomElegance.Common.Entities;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Data.IRepository;

namespace HandloomElegance.Data.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly HandloomEleganceDbContext _HandloomEleganceDbContext;
        public AddressRepository(HandloomEleganceDbContext HandloomEleganceDbContext)
        {
            _HandloomEleganceDbContext = HandloomEleganceDbContext;

        }

        public async Task AddAddress(Address address){
            await _HandloomEleganceDbContext.Addresses.AddAsync(address);
            await SaveChanges();
        }

        public async Task UpdateAddress(Address address){
             _HandloomEleganceDbContext.Addresses.Update(address);
            await SaveChanges();
        }


        public async Task SaveChanges(){
            await _HandloomEleganceDbContext.SaveChangesAsync();
        }

        public Address? FindAddress(Guid AddressId){
            return _HandloomEleganceDbContext.Addresses.Find(AddressId);

        }

        public async Task SoftDeleteAddress(Address address){
            _HandloomEleganceDbContext.Addresses.Update(address);
            await SaveChanges();
        }

        public IEnumerable<UserAddressListViewmodel>GetuserAddressbyUserId(Guid userId){

            return _HandloomEleganceDbContext.Addresses.Where(e=>e.UserId==userId && e.IsActive==true) 
            .Select(i=>new UserAddressListViewmodel{
                AddressId=i.AddressId,
                StreetAddress=i.StreetAddress,
                City=i.City,
                State=i.State,
                PostalCode=i.PostalCode,
                Country=i.Country,
            }).ToList();
            
        }


    }

}