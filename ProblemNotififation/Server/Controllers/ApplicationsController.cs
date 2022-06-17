using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProblemNotififation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly DataContext _context;

        public ApplicationsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Application>>> GetApplications()
        {

            var apps = await _context.Applications.ToListAsync();
            return Ok(apps);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Application>> GetSingleApplication(int id)
        {

            var application = await _context.Applications
                .FirstOrDefaultAsync(a => a.Id == id);

            if (application == null)
            {

                return NotFound("Sorry, no information here. :/");

            }
            return Ok(application);

        }

        [HttpPost]

        public async Task<ActionResult<List<Application>>> CreateApp(Application app)
        {

           
            _context.Applications.Add(app);
            await _context.SaveChangesAsync();

            return Ok(await GetDbApplications());
        }


        [HttpPut("{id}")]

        public async Task<ActionResult<List<Application>>> UpdateApp(Application app, int id)
        {
            var dbApplication = await _context.Applications
                .FirstOrDefaultAsync(a => a.Id == id);
            if (dbApplication == null)
                return NotFound("Sorry, but no hero for you. :/");

            dbApplication.Name = app.Name;
            dbApplication.Description = app.Description;
            


            await _context.SaveChangesAsync();

            return Ok(await GetDbApplications());
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Application>>> DeleteApp(int id)
        {
            var dbApplication = await _context.Applications
                .FirstOrDefaultAsync(a => a.Id == id);
            if (dbApplication == null)
                return NotFound("Sorry, but no hero for you. :/");

            _context.Applications.Remove(dbApplication);
            await _context.SaveChangesAsync();

            return Ok(await GetDbApplications());
        }




        private async Task<List<Application>> GetDbApplications()
        {

            return await _context.Applications.ToListAsync();

        }
    }
}
