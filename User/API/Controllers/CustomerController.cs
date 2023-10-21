using DAL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerBusiness _uBusiness;
        public CustomerController(ICustomerBusiness cBusiness)
        {
            _uBusiness = cBusiness;
        }

        [HttpGet("get-all-Customer")]
        public IActionResult GetAll()
        {
            var dt = _uBusiness.GetAll();
            return Ok(dt);
        }

        [Route("Create-Customer")]
        [HttpPost]
        public CustomerModel CreateCar([FromBody] CustomerModel customer)
        {
            _uBusiness.Create(customer);
            return customer;
        }

        [Route("update-Customer")]
        [HttpPost]
        public CustomerModel UpdateItem([FromBody] CustomerModel customer)
        {
            _uBusiness.Update(customer);
            return customer;
        }

        [HttpDelete("delete-Customer")]
        public IActionResult DeleteItem(string id)
        {
            _uBusiness.Delete(id);
            return Ok(new { message = "xoa thanh cong" });
        }


    }
}
