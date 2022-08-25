using TodoAPI.Infrastructure;

namespace TodoAPI.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieDbContext _dbContext;

        public UnitOfWork(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
