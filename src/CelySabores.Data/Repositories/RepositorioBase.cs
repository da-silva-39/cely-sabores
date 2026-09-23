namespace CelySabores.Data.Repositories
{
    public abstract class RepositorioBase
    {
        protected readonly Database.CommandHelper Db;

        protected RepositorioBase(Database.CommandHelper commandHelper)
        {
            Db = commandHelper;
        }
    }
}