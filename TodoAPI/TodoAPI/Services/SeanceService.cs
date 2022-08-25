using TodoAPI.Models;
using TodoAPI.Dto;
using TodoAPI.Repositories;
using TodoAPI.Infrastructure.UoW;

namespace TodoAPI.Services
{
    public class SeanceService : ISeanceService
    {
        private readonly ISeanceRepository _seanceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SeanceService(ISeanceRepository seanceRepository, IUnitOfWork unitOfWork)
        {
            _seanceRepository = seanceRepository;
            _unitOfWork = unitOfWork;
        }

        public List<Seance> GetSeances()
        {
            return _seanceRepository.GetSeances();
        }

        public int CreateSeance(SeanceDto seance)
        {
            if (seance == null)
            {
                throw new Exception($"{nameof(seance)} not found");
            }

            Seance seanceEntity = seance.ConvertToSeance();

            int id = _seanceRepository.Create(seanceEntity);
            _unitOfWork.Commit();
            return id;
        }

        public void DeleteSeance(int seanceId)
        {
            Seance seance = _seanceRepository.Get(seanceId);
            if (seance == null)
            {
                throw new Exception($"{nameof(seance)} not found, #Id - {seanceId}");
            }

            _seanceRepository.Delete(seance);
            _unitOfWork.Commit();
        }

        public Seance GetSeance(int seanceId)
        {
            Seance seance = _seanceRepository.Get(seanceId);
            if (seance == null)
            {
                throw new Exception($"{nameof(seance)} not found, #Id - {seanceId}");
            }

            return seance;
        }

        List<Seance> ISeanceService.GetSeances()
        {
            throw new NotImplementedException();
        }

        int ISeanceService.CreateSeance(SeanceDto seance)
        {
            throw new NotImplementedException();
        }
    }
}
