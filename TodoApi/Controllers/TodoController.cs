using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        // GET: api/<TodoContoller>
        [HttpGet]
        public List<Todo> Get()
        {
            var db = new Database();
            var todos = db.GetTodosFromDatabase();
            return todos;
            
        }

        // GET api/<TodoContoller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var db = new Database();
            var todo = db.GetTodoById(id);

            if(todo == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(todo);
            }          
        }

        // POST api/<TodoContoller>
        [HttpPost]
        public void Post([FromBody] Todo todo)
        {
            var db = new Database();
            db.CreateNewTodo(todo);
        }

        // PUT api/<TodoContoller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodoContoller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var db = new Database();
            db.DeleteTodo(id);
        }
    }
}
