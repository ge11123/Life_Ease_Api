using LifeManage.src.Infrastructure.BaseModels;
using System.Linq.Expressions;

namespace LifeManage.src.Infrastructure.Repositories.Interfaces
{
	public interface IGenericRepository<TEntity> : IDisposable where TEntity : class
	{
		#region Query
		List<T> ExecSQL<T>(string query);
		Task<List<T>> QueryAsync<T>(Expression<Func<TEntity, bool>> predicate);
		Task<PageResult<T>> QueryAsync<T>(Expression<Func<TEntity, bool>> predicate, QueryOption options);
		Task<T> SingleOrDefaultAsync<T>(Expression<Func<TEntity, bool>> predicate);
		Task<T> FirstOrDefaultAsync<T>(Expression<Func<TEntity, bool>> predicate);
		#endregion

		#region Insert
		Task<T> InsertAsync<T>(T dto);
		Task<IEnumerable<T>> InsertRangeAsync<T>(IEnumerable<T> dtos);
		#endregion

		#region Update
		Task<int> UpdateAsync(TEntity entity);
		Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities);
		#endregion

		#region Delete
		Task<int> DeleteAsync(TEntity entity);
		Task<int> DeleteRangeAsync(IEnumerable<TEntity> entities);
		#endregion
	}
}
