using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timothy_Hsu_MVC.Interfaces
{
    public interface IRepository
    {
        Task<List<T>> SelectAllAsync<T>() where T : class;
        Task<T> SelectByIdAsync<T>(int id) where T : class;
        Task CreateAsync<T>(T entity) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
    }
}
