using TodoAPI.Infrastructure;
using TodoAPI.Models;

namespace TodoAPI.Repositories

{
    public class TicketsRepository : ITicketsRepository
    {
        private readonly MovieDbContext _dbContext;

        public TicketsRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Tickets> GetTickets()
        {
            return _dbContext.Tickets.ToList();
        }

        public Tickets Get(int id)
        {
            return _dbContext.Tickets.FirstOrDefault(x => x.Id == id);
        }

        public int Create(Tickets ticket)
        {
            return _dbContext.Tickets.Add(ticket).Entity.Id;
        }

        public void Delete(Tickets ticket)
        {
            _dbContext.Tickets.Remove(ticket);
        }

        public void Update(Tickets ticket)
        {
            _dbContext.Tickets.Update(ticket);
        }
    }
}
