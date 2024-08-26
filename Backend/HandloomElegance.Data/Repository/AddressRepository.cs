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


        public async Task SaveChanges(){
            await _HandloomEleganceDbContext.SaveChangesAsync();
        }


    }

}