using TodoAPI.Models;

namespace TodoAPI.Repositories
{
    public interface IFilmRepository
    {
        List<Film> GetFilms();
        Film Get(int id);
        int Create(Film film);
        void Delete(Film film);
        void Update(Film film);
    }
}
