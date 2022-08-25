namespace TodoAPI.Infrastructure.UoW
{
    public interface IUnitOfWork
    {
        public void Commit();
    }
}
