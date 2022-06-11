namespace CarRental.Core.Entity.Abstract
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}