using DAL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ColectionController : ControllerBase
    {
        private IColectionBusiness _uBusiness;
        public ColectionController(IColectionBusiness cBusiness)
        {
            _uBusiness = cBusiness;
        }

        [HttpGet("get-all-Colection")]
        public IActionResult GetAll()
        {
            var dt = _uBusiness.GetAll();
            return Ok(dt);
        }

        [Route("Create-Colection")]
        [HttpPost]
        public ColectionModel CreateCar([FromBody] ColectionModel colection)
        {
            _uBusiness.Create(colection);
            return colection;
        }

        [Route("update-Colection")]
        [HttpPost]
        public ColectionModel UpdateItem([FromBody] ColectionModel colection)
        {
            _uBusiness.Update(colection);
            return colection;
        }

        [HttpDelete("delete-Colection")]
        public IActionResult DeleteItem(string id)
        {
            _uBusiness.Delete(id);
            return Ok(new { message = "xoa thanh cong" });
        }


    }
}
