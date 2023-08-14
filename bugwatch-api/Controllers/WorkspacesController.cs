using bugwatch_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bugwatch_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkspacesController : ControllerBase
    {
        private readonly ILogger<WorkspacesController> _logger;
        private readonly ApplicationContext _context;
        
        public WorkspacesController(ILogger<WorkspacesController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }
        // GET: api/workspaces/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            Workspace? workspace = await _context.Workspaces.FindAsync(Id);
            if(workspace is null)
            {
                return NotFound();
            }
            return Ok(workspace);
        }
        // GET: api/workspaces/
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.AgileTasks.ToListAsync());
        }
        // DELETE: api/workspaces/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            Workspace? workspace = await _context.Workspaces.FindAsync(Id);
            if(workspace is null)
            {
                return NotFound();
            }
            _context.Remove(workspace);
            await _context.SaveChangesAsync();

            return Ok(workspace);
        }
        // PUT: api/workspaces/
        [HttpPut]
        public async Task<IActionResult> Put(Workspace workspace)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            if (_context.AgileTasks.Any(x => x.Id == workspace.Id))
                return NotFound();

            _context.Update(workspace);
            await _context.SaveChangesAsync();
            return Ok(workspace);
        }
        // POST: api/workspaces/
        [HttpPost]
        public async Task<IActionResult> Post(Workspace workspace)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Add(workspace);
            await _context.SaveChangesAsync();
            return Ok(workspace);
        }
    }
}