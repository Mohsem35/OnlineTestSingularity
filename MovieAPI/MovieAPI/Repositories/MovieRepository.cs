using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _db;
        public MovieRepository(MovieDbContext db)
        {
            _db = db;
        }

        public async Task<Movie> Create(Movie movie)
        {
            _db.Movies.Add(movie);
            await _db.SaveChangesAsync();
            return movie;
        }

        public async Task Delete(int id)
        {
            Movie delete = _db.Movies.Where(w => w.Id == id).FirstOrDefault();
            _db.Movies.Remove(delete);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _db.Movies.ToListAsync();
        }

        public async Task<Movie> Get(int id)
        {
            return await _db.Movies.FindAsync(id);
        }

        public async Task Update(Movie movie)
        {
            _db.Entry(movie).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
