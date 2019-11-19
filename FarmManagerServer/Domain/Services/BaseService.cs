using Domain.Abstract;
using System.Collections.Generic;

namespace Domain.Services
{
    public abstract class BaseService<T> where T : class, IBaseEntity
    {
        #region Properties

        protected IRepositoryBase<T> MainRepository { get; private set; }

        #endregion
        #region Constructors

        public BaseService(IRepositoryBase<T> mainRepository)
        {
            MainRepository = mainRepository;
        }

        #endregion
        #region Members

        public IEnumerable<T> GetAll()
        {
            return MainRepository.FindAll();
        }

        public T GetById(long id)
        {
            return MainRepository.FindFirstOrDefault(x => x.Id == id);
        }

        public T Update(T entity)
        {
            return MainRepository.Update(entity);
        }

        public void Delete(long id)
        {
            var entity = GetById(id);

            if (entity != null)
            {
                MainRepository.Delete(entity);
            }
        }

        public T Add(T entity)
        {
            return MainRepository.Add(entity);
        }

        #endregion
    }
}
