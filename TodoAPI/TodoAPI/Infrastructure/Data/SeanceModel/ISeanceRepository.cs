using TodoAPI.Models;

namespace TodoAPI.Repositories
{
    public interface ISeanceRepository
    {
        List<Seance> GetSeances();
        Seance Get(int id);
        int Create(Seance seance);
        void Delete(Seance seance);
        void Update(Seance seance);
    }
}
