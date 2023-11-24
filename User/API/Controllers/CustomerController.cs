using DAL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerBusiness _uBusiness;
        public CustomerController(ICustomerBusiness cBusiness)
        {
            _uBusiness = cBusiness;
        }


        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(string id)
        {
            var dt = _uBusiness.GetById(id);
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

        [HttpPost("search")]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string name = "";
                if (formData.Keys.Contains("name") && !string.IsNullOrEmpty(Convert.ToString(formData["name"])))
                { name = Convert.ToString(formData["name"]); }

                long total = 0;
                var data = _uBusiness.Search(page, pageSize, out total, name);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
