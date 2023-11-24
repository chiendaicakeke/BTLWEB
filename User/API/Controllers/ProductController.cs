using DAL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

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


        [Route("get-new-product")]
        [HttpGet]
        public IActionResult GetNewProducts()
        {
            var dt = _uBusiness.GetNewProducts();
            return Ok(dt);
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
