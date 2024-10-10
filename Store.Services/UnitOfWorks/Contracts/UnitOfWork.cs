namespace Store.Services;

public interface UnitOfWork
{
    public  Task Save();
    public  Task Begin();
    public  Task Commit();
    public  Task RollBack();
}