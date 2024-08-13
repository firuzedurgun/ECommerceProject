using ECommerce.DAL.Abstract;
using ECommerce.Data.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductDAL _productDAL;
        public ProductsController(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productDAL.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == null || _productDAL.GetAll() == null)
                return BadRequest();

            var product = _productDAL.Get(Convert.ToInt32(id));

            if (product == null)
                return NotFound("Product is not found!!!");

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                _productDAL.Add(product);
                return CreatedAtAction("Get", new { id = product.Id }, product);//Status Code 201
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                _productDAL.Update(product);
                return Ok(product);
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var product = _productDAL.Get(i => i.Id == id);

            if (product == null)
                return BadRequest();

            _productDAL.Delete(id);
            return Ok();
        }
    }
}
