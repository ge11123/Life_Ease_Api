using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Claims;
using TodoList.WebAPI.src.TodoList.Infrastructure.BaseModels;
using TodoList.WebAPI.src.TodoList.Infrastructure.Repositories.Interfaces;

namespace TodoList.WebAPI.src.TodoList.Infrastructure.Repositories
{
	public class BaseRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		private DbContext _context;
		private readonly IMapper _mapper;
		private readonly ClaimsPrincipal _clams;

		#region ctor
		public BaseRepository(DbContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context fail");
			}
		}
		public BaseRepository(DbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public BaseRepository(DbContext context, IMapper mapper, ClaimsPrincipal clams)
		{
			_context = context;
			_mapper = mapper;
			_clams = clams;
		}
		#endregion

		#region protected
		protected virtual IQueryable<TEntity> QueryProcess()
		{
			return _context.Set<TEntity>().AsNoTracking();
		}
		protected virtual void InsertProcess(TEntity entity)
		{
			_context.Entry(entity).State = EntityState.Added;
		}
		protected virtual void UpdateProcess(TEntity entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
		}
		protected virtual void DeleteProcess(TEntity entity)
		{
			_context.Entry(entity).State = EntityState.Deleted;
		}
		protected virtual async Task<int> SaveChangesAsync()
		{
			if (_clams != null)
			{
				var absn = Convert.ToString(_clams.Identity.Name);
				//_context.SaveChangesProcess(absn);
			}
			return await _context.SaveChangesAsync();
		}
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this._context != null)
				{
					this._context.Dispose();
					this._context = null;
				}
			}
		}
		#endregion

		#region Query
		// 變數名稱要跟SQL裡的一樣, 例:Basic_SN 不能改為BasicSn
		public List<T> ExecSQL<T>(string query)
		{
			using (var command = _context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = query;
				command.CommandType = CommandType.Text;
				_context.Database.OpenConnection();

				List<T> list = new List<T>();
				using (var result = command.ExecuteReader())
				{
					T obj = default(T);
					while (result.Read())
					{
						obj = Activator.CreateInstance<T>();
						foreach (PropertyInfo prop in obj.GetType().GetProperties())
						{
							if (!object.Equals(result[prop.Name], DBNull.Value))
							{
								prop.SetValue(obj, result[prop.Name], null);
							}
						}
						list.Add(obj);
					}
				}
				_context.Database.CloseConnection();
				return list;
			}
		}

		

		public async Task<List<T>> QueryAsync<T>(Expression<Func<TEntity, bool>> predicate)
		{
			var query = QueryProcess();

			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			return await _mapper.ProjectTo<T>(query).ToListAsync();
		}

		public async Task<PageResult<T>> QueryAsync<T>(Expression<Func<TEntity, bool>> predicate, QueryOption options)
		{
			var query = QueryProcess();

			if (predicate != null)
			{
				query = query.Where(predicate);
			}

			if (options == null)
			{
				options = new QueryOption();
			}

			var items = await _mapper.ProjectTo<T>(options.ApplyTo(query)).ToListAsync();
			var totalCount = await query.CountAsync();

			return new PageResult<T>(items, totalCount);
		}

		public async Task<T> SingleOrDefaultAsync<T>(Expression<Func<TEntity, bool>> predicate)
		{
			var query = QueryProcess();

			if (predicate != null)
			{
				query = query.Where(predicate);
			}

			return await _mapper.ProjectTo<T>(query).SingleOrDefaultAsync();
		}

		public async Task<T> FirstOrDefaultAsync<T>(Expression<Func<TEntity, bool>> predicate)
		{
			var query = QueryProcess();

			if (predicate != null)
			{
				query = query.Where(predicate);
			}

			return await _mapper.ProjectTo<T>(query).FirstOrDefaultAsync();
		}

		#endregion

		#region Insert
		public async Task<T> InsertAsync<T>(T dto)
		{
			var entity = _mapper.Map<TEntity>(dto);

			InsertProcess(entity);
			await SaveChangesAsync();

			return _mapper.Map<T>(entity);
		}

		public async Task<IEnumerable<T>> InsertRangeAsync<T>(IEnumerable<T> dtos)
		{
			if (dtos.Any() == false)
			{
				return new List<T>();
			}

			var entities = _mapper.Map<List<TEntity>>(dtos.ToList());
			foreach (var entity in entities)
			{
				InsertProcess(entity);
			}

			await SaveChangesAsync();

			return _mapper.Map<List<T>>(entities.ToList());
		}
		#endregion

		#region Update
		public async Task<int> UpdateAsync(TEntity entity)
		{

			UpdateProcess(entity);
			return await SaveChangesAsync();
		}

		public async Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities)
		{
			if (entities.Any() == false)
			{
				return 0;
			}

			foreach (var entity in entities)
			{
				UpdateProcess(entity);
			}

			return await SaveChangesAsync();
		}
		#endregion

		#region Delete
		public async Task<int> DeleteAsync(TEntity entity)
		{
			DeleteProcess(entity);
			return await SaveChangesAsync();
		}

		public async Task<int> DeleteRangeAsync(IEnumerable<TEntity> entities)
		{
			if (entities.Any() == false)
			{
				return 0;
			}

			foreach (var entity in entities)
			{
				DeleteProcess(entity);
			}

			return await SaveChangesAsync();
		}

		#endregion

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

	}
}
}
