using DAL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersBusiness _uBusiness;
        public UsersController(IUsersBusiness cBusiness)
        {
            _uBusiness = cBusiness;
        }

        [HttpGet("get-all-Users")]
        public IActionResult GetAll()
        {
            var dt = _uBusiness.GetAll();
            return Ok(dt);
        }

        [Route("Create-Users")]
        [HttpPost]
        public UsersModel CreateCar([FromBody] UsersModel users)
        {
            _uBusiness.Create(users);
            return users;
        }

        [Route("update-Users")]
        [HttpPost]
        public UsersModel UpdateItem([FromBody] UsersModel users)
        {
            _uBusiness.Update(users);
            return users;
        }

        [HttpDelete("delete-Users")]
        public IActionResult DeleteItem(string id)
        {
            _uBusiness.Delete(id);
            return Ok(new { message = "xoa thanh cong" });
        }


    }
}
