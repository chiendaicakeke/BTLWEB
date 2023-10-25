using DAL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private IBillBusiness _uBusiness;
        public BillController(IBillBusiness cBusiness)
        {
            _uBusiness = cBusiness;
        }

        [HttpGet("get-all-Bill")]
        public IActionResult GetAll()
        {
            var dt = _uBusiness.GetAll();
            return Ok(dt);
        }

        [Route("create-Bill")]
        [HttpPost]
        public BillModel CreateCar([FromBody] BillModel bill)
        {
            _uBusiness.Create(bill);
            return bill;
        }

        [Route("update-Bill")]
        [HttpPost]
        public BillModel UpdateItem([FromBody] BillModel bill)
        {
            _uBusiness.Update(bill);
            return bill;
        }

        [HttpDelete("delete-Bill")]
        public IActionResult DeleteItem(string id)
        {
            _uBusiness.Delete(id);
            return Ok(new { message = "xoa thanh cong" });
        }


    }
}
