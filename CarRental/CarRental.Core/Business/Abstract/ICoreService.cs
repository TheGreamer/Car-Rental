using CarRental.Core.DataAccess.Abstract;
using CarRental.Core.Entity.Concrete;

namespace CarRental.Core.Business.Abstract
{
    public interface ICoreService<TEntity, TDal> : IService<TEntity>
        where TEntity : CoreEntity, new()
        where TDal : IEntityRepository<TEntity>
    {
    }
}