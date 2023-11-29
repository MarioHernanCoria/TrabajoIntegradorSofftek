using Microsoft.EntityFrameworkCore;
using TrabajoIntegradorSofftek.DataAccess.Repositories.Interfaces;
using TrabajoIntegradorSofftek.Entities;

namespace TrabajoIntegradorSofftek.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
	{
		protected readonly AppDbContext _context;

		public Repository(AppDbContext context)
		{
			_context = context;
		}

		public virtual async Task<List<T>> GetAll()
		{
			return await _context.Set<T>().ToListAsync();
		}	

		public virtual async Task<T> GetById(int id)
		{
			return await _context.Set<T>().FindAsync(id);
	
		}

		public virtual async Task<bool> Insert(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			return true;
		}

		public virtual async Task<bool> Update(T entity)
		{
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> Delete(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public virtual Task<bool> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }


    }
}
