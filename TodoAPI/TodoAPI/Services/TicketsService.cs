using TodoAPI.Models;
using TodoAPI.Dto;
using TodoAPI.Repositories;
using TodoAPI.Infrastructure.UoW;

namespace TodoAPI.Services
{
    public  class TicketsService : ITicketsService
    {
        private readonly ITicketsRepository _ticketsRepository;
        private readonly IUnitOfWork _unitOfWork;
        public TicketsService(ITicketsRepository ticketsRepository, IUnitOfWork unitOfWork)
        {
            _ticketsRepository = ticketsRepository;
            _unitOfWork = unitOfWork;
        }

        public List<Tickets> GetTickets()
        {
            return _ticketsRepository.GetTickets();
        }

        public int CreateTicket(TicketsDto ticket)
        {
            if (ticket == null)
            {
                throw new Exception($"{nameof(ticket)} not found");
            }

            Tickets ticketEntity = ticket.ConvertToTickets();

            int id =  _ticketsRepository.Create(ticketEntity);
            _unitOfWork.Commit();
            return id;
        }

        public void DeleteTicket(int ticketId)
        {
            Tickets ticket = _ticketsRepository.Get(ticketId);
            if (ticket == null)
            {
                throw new Exception($"{nameof(ticket)} not found, #Id - {ticketId}");
            }

            _ticketsRepository.Delete(ticket);
            _unitOfWork.Commit();
        }

        public Tickets GetTicket(int ticketId)
        {
            Tickets ticket = _ticketsRepository.Get(ticketId);
            if (ticket == null)
            {
                throw new Exception($"{nameof(ticket)} not found, #Id - {ticketId}");
            }

            return ticket;
        }
    }
}
