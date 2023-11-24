using DAL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OderController : ControllerBase
    {
        private IOderBusiness _uBusiness;
        public OderController(IOderBusiness cBusiness)
        {
            _uBusiness = cBusiness;
        }

        [HttpGet("get-all-Oder")]
        public IActionResult GetAll()
        {
            var dt = _uBusiness.GetAll();
            return Ok(dt);
        }

        [Route("Create-Oder")]
        [HttpPost]
        public OderModel CreateCar([FromBody] OderModel oder)
        {
            _uBusiness.Create(oder);
            return oder;
        }

        [Route("update-Oder")]
        [HttpPost]
        public OderModel UpdateItem([FromBody] OderModel oder)
        {
            _uBusiness.Update(oder);
            return oder;
        }

        [HttpDelete("delete-Oder")]
        public IActionResult DeleteItem(string id)
        {
            _uBusiness.Delete(id);
            return Ok(new { message = "xoa thanh cong" });
        }


    }
}
