using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceComputer.Reponsive.Base
{
    public interface IReponsive<T> where T:class
    {
        string noticationErr { get; set; }
        bool checkStatus {  get; set; }
        Task<T> GetId(int id);
        Task<List<T>> GetAll();
        Task CreateRepo(T entity);
        Task UpdateRepo(T entity);
        Task DeleteRepo(int id);
    }
}
