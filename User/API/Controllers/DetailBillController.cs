using DAL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DetailBillController : ControllerBase
    {
        private IDetailBillBusiness _uBusiness;
        public DetailBillController(IDetailBillBusiness cBusiness)
        {
            _uBusiness = cBusiness;
        }

        [HttpGet("get-all-DetailBill")]
        public IActionResult GetAll()
        {
            var dt = _uBusiness.GetAll();
            return Ok(dt);
        }

        [Route("Create-DetailBill")]
        [HttpPost]
        public DetailBillModel CreateCar([FromBody] DetailBillModel detailbill)
        {
            _uBusiness.Create(detailbill);
            return detailbill;
        }

        [Route("update-DetailBill")]
        [HttpPost]
        public DetailBillModel UpdateItem([FromBody] DetailBillModel detailbill)
        {
            _uBusiness.Update(detailbill);
            return detailbill;
        }

        [HttpDelete("delete-DetailBill")]
        public IActionResult DeleteItem(string id)
        {
            _uBusiness.Delete(id);
            return Ok(new { message = "xoa thanh cong" });
        }

        [HttpGet("get-by-id{id}")]
        public DetailBillModel GetDataById(string id) => _uBusiness.GetDataById(id);

    }
}
