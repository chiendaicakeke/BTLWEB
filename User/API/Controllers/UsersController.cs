using DAL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersBusiness _uBusiness;
        public UsersController(IUsersBusiness cBusiness)
        {
            _uBusiness = cBusiness;
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(string id)
        {
            var dt = _uBusiness.GetById(id);
            return Ok(dt);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateUsersModel model)
        {
            var user = _uBusiness.Login(model.UserName, model.Password);
            if (user == null)
                return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            return Ok(new { taikhoan = user.UserName, role = user.Role, token = user.token });
        }


        [Route("create-Users")]
        [HttpPost]
        public UserModel CreateCar([FromBody] UserModel users)
        {
            _uBusiness.Create(users);
            return users;
        }

        [Route("update-Users")]
        [HttpPost]
        public UserModel UpdateItem([FromBody] UserModel users)
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
