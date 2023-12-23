namespace AppKi.DataAccess.Abstractions;

public interface IIdentifiable<out T>
{
    T Id { get; }
}