using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdyUI.Repository.IRepository
{
    public interface IRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAllAsync(string url);
        Task<T> GetAsync(string url,string id);
        Task<bool> CreateAsync(string url, T model);
        Task<bool> UpdateAsync(string url, T model, string id);
        Task<bool> DeleteAsync(string url, string id);
    }
}
