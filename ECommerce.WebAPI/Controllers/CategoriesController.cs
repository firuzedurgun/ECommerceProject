using ECommerce.DAL.Abstract;
using ECommerce.Data.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryDAL _IcategoryDAL;

        public CategoriesController(ICategoryDAL icategoryDAL)
        {
            _IcategoryDAL = icategoryDAL;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_IcategoryDAL.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == null || _IcategoryDAL.GetAll() == null)
                return BadRequest();

            var category = _IcategoryDAL.Get(Convert.ToInt32(id));
            if (category == null)
                return NotFound("Category Not Found!!!");

            return Ok(category);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                _IcategoryDAL.Add(category);

                return CreatedAtAction("Get", new { id = category.Id }, category);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                _IcategoryDAL.Update(category);
                return Ok(category);
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var category = _IcategoryDAL.Get(i => i.Id == id);

            if (category == null)
                return BadRequest();

            _IcategoryDAL.Delete(id);
            return Ok();
        }
    }
}
