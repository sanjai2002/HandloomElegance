using Microsoft.AspNetCore.Mvc;
using HandloomElegance.Core.IServices;
using HandloomElegance.Common.ViewModels;
namespace HandloomElegance.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserServices _IUserServices;
        public UserController(IUserServices IUserServices)
        {
            _IUserServices = IUserServices;

        }
        [HttpPost]
        public async Task<IActionResult> UserRegistration(UserRegisterViewModel Register)
        {
            bool user = await _IUserServices.UserRegister(Register);
            if (user == true)
            {
                return Ok("Register Successfully");
            }
            else if (user == false)
            {
                return Ok("Already Email id Exits");
            }
            else
            {
                return Ok("Not Registered");
            }

        }

    }


}