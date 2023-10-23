using DAL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private IFavoriteBusiness _uBusiness;
        public FavoriteController(IFavoriteBusiness cBusiness)
        {
            _uBusiness = cBusiness;
        }

        [HttpGet("get-all-Favorite")]
        public IActionResult GetAll()
        {
            var dt = _uBusiness.GetAll();
            return Ok(dt);
        }

        [Route("Create-Favorite")]
        [HttpPost]
        public FavoriteModel CreateCar([FromBody] FavoriteModel favorite)
        {
            _uBusiness.Create(favorite);
            return favorite;
        }

        [Route("update-Favorite")]
        [HttpPost]
        public FavoriteModel UpdateItem([FromBody] FavoriteModel favorite)
        {
            _uBusiness.Update(favorite);
            return favorite;
        }

        [HttpDelete("delete-Favorite")]
        public IActionResult DeleteItem(string id)
        {
            _uBusiness.Delete(id);
            return Ok(new { message = "xoa thanh cong" });
        }


    }
}
