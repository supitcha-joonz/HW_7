using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProblemNotififation.Shared;

namespace ProblemNotififation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemNoticeController : ControllerBase
    {
        private readonly DataContext _context;

        public ProblemNoticeController(DataContext context) {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Problem>>> GetProblems() {

           
            var problems = await _context.Problems.Include(pr => pr.Application).ToListAsync();
            return Ok(problems);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Problem>> GetSingleProblem(int id) {
            
            var problem = await _context.Problems
                .Include(p => p.Application)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (problem == null) {

                return NotFound("Sorry, no information here. :/");
            
            }
            return Ok(problem);
            
        }

        [HttpPost]

        public async Task<ActionResult<List<Problem>>> Create(Problem pro)
        {

            pro.Application = null;
            _context.Problems.Add(pro);
            await _context.SaveChangesAsync();

            return Ok(await GetDbProblems());
        }


        [HttpPut("{id}")]

        public async Task<ActionResult<List<Problem>>> Update(Problem pro, int id)
        {
            var dbProblem = await _context.Problems
                .Include(p => p.Application)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (dbProblem == null)
                return NotFound("Sorry, but no hero for you. :/");

            dbProblem.FirstName = pro.FirstName;
            dbProblem.LastName = pro.LastName;
            dbProblem.ApplicationId = pro.ApplicationId;
            dbProblem.ProblemName = pro.ProblemName;
            dbProblem.Description = pro.Description;


            await _context.SaveChangesAsync();

            return Ok(await GetDbProblems());
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Problem>>> Delete(int id)
        {
            var dbProblem = await _context.Problems
                .Include(p => p.Application)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (dbProblem == null)
                return NotFound("Sorry, but no hero for you. :/");

            _context.Problems.Remove(dbProblem);
            await _context.SaveChangesAsync();

            return Ok(await GetDbProblems());
        }




        private async Task<List<Problem>> GetDbProblems()
        {

            return await _context.Problems.Include(p => p.Application).ToListAsync();

        }




    }
}
