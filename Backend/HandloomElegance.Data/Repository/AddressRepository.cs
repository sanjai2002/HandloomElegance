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





    }

}