using Microsoft.AspNetCore.Mvc; 
using MODUL10_103022300134.Data; 
using MODUL10_103022300134.Model; 
using Microsoft.EntityFrameworkCore; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 
using Microsoft.Extensions.Logging;

namespace MODUL10_103022300134.Controllers
{
   [Route("api/[controller]")] 
   [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly AppDbContext _context; 

        public MovieController(AppDbContext context)
        { 
            _context = context; 
        }   
        [HttpGet] 
         public async Task<ActionResult<IEnumerable<Movie>>>GetMovies()
         { 
             return await _context.Movies.ToListAsync(); 
         } 
 
        [HttpGet("{id}")] 
         public async Task<ActionResult<Movie>> GetMovie(int title)
         { 
            var movie = await _context.Movies.FindAsync(title);   
            if (movie == null)
             {
                return NotFound(); 
             } 
  
             return movie; 
         } 
  
         [HttpPost] 
         public async Task<ActionResult<Movie>>PostMahasiswa(Movie movie)
         { 
             _context.Movies.Add(movie); 
             await _context.SaveChangesAsync(); 
  
             return CreatedAtAction(nameof(GetMovie), new { id = movie.Title }, movie); 
         } 
  
         [HttpPut("{id}")] 
        public async Task<IActionResult> PutMovie(int title, Movie movie)
         { 
             if (title != movie.Title)
             { 
                 return BadRequest(); 
            } 
  
             _context.Entry(movie).State = EntityState.Modified; 
  
            try
             { 
                 await _context.SaveChangesAsync(); 
             } 
             catch (DbUpdateConcurrencyException)
            { 
                 if (!MovieExists(title))
                 { 
                     return NotFound(); 
                 } 
                 else
                { 
                     throw; 
                 } 
             } 
  
            return NoContent(); 
         } 
 
         [HttpDelete("{id}")]


        public async Task<IActionResult> DeleteMovie(int id)
         
    { 
             
        var movie = await _context.Movies.FindAsync(id); 
             
        if (movie == null) 
             
    { 
                 
        return NotFound(); 
             
    } 
  
             
        _context.Movies.Remove(movie); 
             
        await _context.SaveChangesAsync(); 
  
             
        return NoContent(); 
         
    }


        private bool MovieExists(int title)

        {

            return _context.Movies.Any(e => e.Title == title);

        }
}
}
