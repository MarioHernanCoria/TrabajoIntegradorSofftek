namespace TrabajoIntegradorSofftek.DataAccess.Repositories.Interfaces
{
	public interface IRepository<T> where T : class
	{
		public Task<List<T>> GetAll();
		public Task<T> GetById(int id);
		public Task<bool> Update(T Entity);
		public Task<bool> Delete(int id);
        Task<bool> GetByEmail(string email);
    }
}
