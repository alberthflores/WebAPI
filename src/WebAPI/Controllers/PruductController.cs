using DtoLayer;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class PruductController : ControllerBase
    {
        private readonly IProductService productService;

        public PruductController(IProductService productService)
        {
            this.productService = productService;
        }
        // GET: api/<PruductController>
        [HttpGet]
        public ActionResult<List<ProductDto>> Get()
        {
            return Ok(productService.GetAll());
        }

        // GET api/<PruductController>/5
        [HttpPatch("{id}")]
        public IActionResult Path(int id)
        {
            var productDto = productService.GetById(id);
            if (productDto is null)
            {
                return BadRequest("NO EXISTE EL PRODUCTO");
            }
            List<string> messages = new List<string>();
            if (!(productDto.Mrp < productDto.Price && productDto.State == true))
            {
                messages.Add("MRP debe ser menor que el price");
            }
            if (!(productDto.Stock > 1))
            {
                messages.Add("Stock no suficiente");
            }
            if (messages.Any())
            {
                return StatusCode(422, messages);
            }
            productService.Path(id);
            return NoContent();
        }

        // POST api/<PruductController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateProductDto product)
        {
            productService.Create(product);
            return StatusCode(201,"producto registrado");
        }

        // PUT api/<PruductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PruductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            productService.Delete(id);
            return StatusCode(201);
        }
    }
}
