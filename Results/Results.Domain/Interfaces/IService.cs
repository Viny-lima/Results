using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Results.Domain.Interfaces
{
    public interface IService<T> : IDisposable
    {
        Task<T> FindById(int id);
        Task<List<T>> FindAll();
        Task<T> Registered(T product);
        Task Delete(T product);
        Task Update(T product);
    }
}
