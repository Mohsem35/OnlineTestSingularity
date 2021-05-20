using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Models;
using MovieAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _movieRepository.GetAll();
        }

        [HttpGet("{id")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            return await _movieRepository.Get(id);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovies([FromBody] Movie movie)
        {
            var newMovie = await _movieRepository.Create(movie);
            return CreatedAtAction(nameof(GetMovies), new { id = newMovie.Id }, newMovie);
        }

        public async Task<ActionResult<Movie>> PutMovies(int id, [FromBody] Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }
            await _movieRepository.Update(movie);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("id")]
        public async Task<ActionResult<Movie>> Delete(int id)
        {
            var delete = _movieRepository.Get(id);
            if (delete == null)
            {
                return NotFound();
            }
            await _movieRepository.Delete(delete.Id);
            return NoContent();
        }
    }
}
