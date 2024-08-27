using Microsoft.AspNetCore.Mvc;
using HandloomElegance.Core.IServices;
using HandloomElegance.Common.ViewModels;
using HandloomElegance.Common.Utils;
using System.Collections;
namespace HandloomElegance.Api.Controllers{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AddressController:ControllerBase{
        private readonly IAddressServices _IAddressServices;
        public AddressController(IAddressServices IAddressServices){
           _IAddressServices= IAddressServices;
        }

        [HttpPost]
        public async Task<IActionResult>AddAddress(AddAddressViewModel address){
            bool userAddress=await _IAddressServices.AddAddress(address);
            if(userAddress){
                return Ok("Address Added");
            }
            return Ok("Address Not Added");
        }

        [HttpPut]
        public async Task<IActionResult>UpdateAddress(UpdateAddressViewModel address){
            bool  userAddress=await _IAddressServices.UpdateAddress(address);
            if(userAddress){
                return Ok("Address Updated");
            } 
            else{
                return Ok("Address Not Updated");
            }

        }

        [HttpPut]
        public async Task<IActionResult>SoftDeleteAddress(Guid AddressId){
            bool address=await _IAddressServices.SoftDeleteAddress(AddressId);
            if(address) return Ok("Address Deleted");
            return Ok("Not Deleted");
        }
        
        [HttpGet]
        public IActionResult GetUserAddress(Guid userId){
            var addresslist =_IAddressServices.GetUserAddressByUserId(userId);
            return Ok(addresslist);
        }
        
    }
    
    }