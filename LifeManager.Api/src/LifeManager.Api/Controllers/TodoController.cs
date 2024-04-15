using LifeManage.src.LifeManager.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.WebAPI.src.TodoList.Api.Controllers
{
    public class TodoController : BaseController
	{
		[HttpGet]
		public IActionResult Get()
		{
			return Ok("Hello World");
		}

		[HttpPost]
		public IActionResult Post()
		{
			return Ok("Hello World");
		}

		[HttpPut]
		public IActionResult Put()
		{
			return Ok("Hello World");
		}

		[HttpDelete]
		public IActionResult Delete()
		{
			return Ok("Hello World");
		}
	}
}
