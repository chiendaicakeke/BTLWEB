using DAL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MixerController : ControllerBase
    {
        private IMixerBusiness _uBusiness;
        public MixerController(IMixerBusiness cBusiness)
        {
            _uBusiness = cBusiness;
        }

        [HttpGet("get-all-Mixer")]
        public IActionResult GetAll()
        {
            var dt = _uBusiness.GetAll();
            return Ok(dt);
        }

        [Route("Create-Mixer")]
        [HttpPost]
        public MixerModel CreateCar([FromBody] MixerModel mixer)
        {
            _uBusiness.Create(mixer);
            return mixer;
        }

        [Route("update-Mixer")]
        [HttpPost]
        public MixerModel UpdateItem([FromBody] MixerModel mixer)
        {
            _uBusiness.Update(mixer);
            return mixer;
        }

        [HttpDelete("delete-Mixer")]
        public IActionResult DeleteItem(string id)
        {
            _uBusiness.Delete(id);
            return Ok(new { message = "xoa thanh cong" });
        }


    }
}
