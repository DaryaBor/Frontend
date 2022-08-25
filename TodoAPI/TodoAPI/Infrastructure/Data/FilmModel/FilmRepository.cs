using System.Data;
using TodoAPI.Infrastructure;
using TodoAPI.Models;

namespace TodoAPI.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly MovieDbContext _dbContext;

        public FilmRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Film> GetFilms()
        {
            return _dbContext.Film.ToList();
        }

        public Film Get(int id)
        {
            return _dbContext.Film.FirstOrDefault(x => x.Id == id);
        }

        public int Create(Film film)
        {
            return _dbContext.Film.Add(film).Entity.Id;
        }

        public void Delete(Film film)
        {
            _dbContext.Film.Remove(film);
        }

        public void Update(Film film)
        {
            _dbContext.Film.Update(film);
        }
    }
}
