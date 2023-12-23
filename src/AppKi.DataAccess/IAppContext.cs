using AppKi.DataAccess.Repositories;

namespace AppKi.DataAccess;

public interface IAppContext
{
    IReferencesRepo References { get; }
}