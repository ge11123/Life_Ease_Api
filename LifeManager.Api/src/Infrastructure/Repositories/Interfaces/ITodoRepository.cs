﻿using LifeManage.src.Domain.Entities;

namespace LifeManage.src.Infrastructure.Repositories.Interfaces
{
	public interface ITodoRepository : IGenericRepository<TodoList>
	{
		Task UpdateTodoAsync(TodoList todoList);
	}
}
