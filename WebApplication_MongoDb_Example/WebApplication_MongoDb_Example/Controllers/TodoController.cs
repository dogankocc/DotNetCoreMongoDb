using Microsoft.AspNetCore.Mvc;
using WebApplication_MongoDb_Example.Models;
using WebApplication_MongoDb_Example.Service;

namespace WebApplication_MongoDb_Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _service;
        public TodoController(ITodoService service) 
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.Get();
            if (result == null)
            {
                return BadRequest("Not found");
            }

            return Ok(result.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var result = _service.GetByIdAsync(id).Result;
            if (result == null)
            {
                return BadRequest("Not found");
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem data)
        {
            var result = _service.AddAsync(data).Result;
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoItem data)
        {
            var result = _service.UpdateAsync(id, data).Result;
            if (result == null)
            {
                return BadRequest("Not found");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var result = _service.DeleteAsync(id).Result;
            if (result == null)
            {
                return BadRequest("Not found");
            }

            return NoContent();
        }
    }


}
