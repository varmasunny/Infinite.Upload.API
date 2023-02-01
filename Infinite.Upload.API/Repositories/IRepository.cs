using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infinite.Upload.API.Repositories
{
    public interface IRepository<T> where T : class
    {
  
            Task Create(T obj);
           

    }
    public interface IGetRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

    }
}
