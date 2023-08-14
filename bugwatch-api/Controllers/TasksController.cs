using bugwatch_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace bugwatch_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;
        private readonly ApplicationContext _context;
        
        public TasksController(ILogger<TasksController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }
        // GET: api/tasks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            AgileTask? agileTask = await _context.AgileTasks.FindAsync(Id);
            if(agileTask is null)
            {
                return NotFound();
            }
            return Ok(agileTask);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            AgileTask? agileTask = await _context.AgileTasks.FindAsync(Id);
            if(agileTask is null)
            {
                return NotFound();
            }
            _context.Remove(agileTask);
            await _context.SaveChangesAsync();

            return Ok(agileTask);
        }
        [HttpPut]
        public async Task<IActionResult> Put(AgileTask agileTask)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            if (_context.AgileTasks.Any(x => x.Id == agileTask.Id))
                return NotFound();

            _context.Update(agileTask);
            await _context.SaveChangesAsync();
            return Ok(agileTask);
        }
        [HttpPost]
        public async Task<IActionResult> Post(AgileTask agileTask)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Add(agileTask);
            await _context.SaveChangesAsync();
            return Ok(agileTask);
        }
    }
}