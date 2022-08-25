using TodoAPI.Models;

namespace TodoAPI.Repositories
{
    public interface ITicketsRepository
    {
        List<Tickets> GetTickets();
        Tickets Get(int id);
        int Create(Tickets ticket);
        void Delete(Tickets ticket);
        void Update(Tickets ticket);
    }
}
