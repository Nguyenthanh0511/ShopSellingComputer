using Microsoft.EntityFrameworkCore;
using ServiceComputer.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceComputer.Reponsive.Base
{
    public class Reponsive<T> : IReponsive<T> where T : class
    {
        public DBServiceComputerContext _context;
        public string noticationErr {  get; set; }
        public bool checkStatus { get; set; }
        public Reponsive(DBServiceComputerContext context) {
            _context = context;
            checkStatus = true;
            noticationErr = "That's oke";
        }
        public async Task CreateRepo(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                checkStatus = false;
                noticationErr = ex.Message;
            }
        }
        public async Task<List<T>> GetAll()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }catch(Exception ex)
            {
                checkStatus = false;
                noticationErr = ex.Message;
                return null;
            }
        }

        public async Task<T> GetId(int id)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);
                return entity;
            }
            catch(Exception ex)
            {
                checkStatus = false;
                noticationErr = ex.Message;
                return null;
            }
        }
        public async Task DeleteRepo(int id)
        {
            try
            {
                var entity = await GetId(id);
                _context.Remove(entity);
                _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                checkStatus = false;
                noticationErr = ex.Message;
            }
        }
        public async Task UpdateRepo(T entity)
        {
            try
            {
                _context.Update(entity);
                _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                checkStatus = false;
                noticationErr = ex.Message;
            }
        }
    }
}
