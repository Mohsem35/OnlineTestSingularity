using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAll();
        Task<Movie> Get(int id);
        Task<Movie> Create(Movie movie);
        Task Update(Movie movie);
        Task Delete(int id);
    }
}
