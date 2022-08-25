using TodoAPI.Models;
using TodoAPI.Infrastructure;

namespace TodoAPI.Repositories
{
    public class SeanceRepository : ISeanceRepository
    {
        private readonly MovieDbContext _dbContext;

        public SeanceRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Seance> GetSeances()
        {
            return _dbContext.Seance.ToList();
        }

        public Seance Get(int id)
        {
            return _dbContext.Seance.FirstOrDefault(x => x.Id == id);
        }

        public int Create(Seance seance)
        {
            return _dbContext.Seance.Add(seance).Entity.Id;
        }

        public void Delete(Seance seance)
        {
            _dbContext.Seance.Remove(seance);
        }

        public void Update(Seance seance)
        {
            _dbContext.Seance.Update(seance);
        }
    }
}
