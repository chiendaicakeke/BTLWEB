using DAL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductBusiness _uBusiness;
        public ProductController(IProductBusiness cBusiness)
        {
            _uBusiness = cBusiness;
        }

        [HttpGet("get-all-Product")]
        public IActionResult GetAll()
        {
            var dt = _uBusiness.GetAll();
            return Ok(dt);
        }

        [Route("Create-Product")]
        [HttpPost]
        public ProductModel CreateCar([FromBody] ProductModel product)
        {
            _uBusiness.Create(product);
            return product;
        }

        [Route("update-Product")]
        [HttpPost]
        public ProductModel UpdateItem([FromBody] ProductModel product)
        {
            _uBusiness.Update(product);
            return product;
        }

        [HttpDelete("delete-Product")]
        public IActionResult DeleteItem(string id)
        {
            _uBusiness.Delete(id);
            return Ok(new { message = "xoa thanh cong" });
        }

        [HttpGet("get-by-id{id}")]
        public ProductModel GetDataById(string id) => _uBusiness.GetDataById(id);

    }
}
