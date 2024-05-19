using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Infrastructure.Interfaces
{
    public interface IBaseInterface<T> where T : class
    {
        Task<List<T>> GetALl();  
        Task<T> GetPorId(int id);
        Task<T> Create(T Model);
        Task<T> update(T Model);
        Task<T> delete(int id);
    }
}
