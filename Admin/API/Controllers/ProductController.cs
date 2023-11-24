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

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(string id)
        {
            var dt = _uBusiness.GetById(id);
            return Ok(dt);
        }


        [Route("create-Product")]
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
