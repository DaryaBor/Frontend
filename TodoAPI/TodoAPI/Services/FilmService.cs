using TodoAPI.Models;
using TodoAPI.Dto;
using TodoAPI.Repositories;
using TodoAPI.Services;
using  TodoAPI.Infrastructure.UoW;

namespace TodoAPI.Services
{
    
        public class FilmService : IFilmService
        {
            private readonly IFilmRepository _filmRepository;
            private readonly IUnitOfWork _unitOfWork;
        public FilmService (IFilmRepository filmRepository, IUnitOfWork unitOfWork)
            {
                _filmRepository = filmRepository;
                 _unitOfWork = unitOfWork;
        }

            public List<Film> GetFilms()
            {
                return _filmRepository.GetFilms();
            }

            public int CreateFilm(FilmDto film)
            {
                if (film == null)
                {
                    throw new Exception($"{nameof(film)} not found");
                }

                Film filmEntity = film.ConvertToFilm();

                int id = _filmRepository.Create(filmEntity);
                _unitOfWork.Commit();

            return id;
        }

            public void DeleteFilm(int filmId)
            {
                Film film = _filmRepository.Get(filmId);
                if (film == null)
                {
                    throw new Exception($"{nameof(film)} not found, #Id - {filmId}");
                }

                _filmRepository.Delete(film);
            _unitOfWork.Commit();
        }

            public Film GetFilm(int filmId)
            {
                Film film = _filmRepository.Get(filmId);
                if (film == null)
                {
                    throw new Exception($"{nameof(film)} not found, #Id - {filmId}");
                }

                return film;
            }
        }
}
