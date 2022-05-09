using Business.Abstracts;
using Core.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		ICategoryService _categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			this._categoryService = categoryService;
		}

		[HttpGet("getallcategories")]
		public IActionResult GetAll()
		{
			return this.ResponseResult(_categoryService.GetAll());
		}

		[HttpGet("getbyid")]
		public IActionResult GetById(int categoryId)
		{
			return this.ResponseResult(_categoryService.GetById(categoryId));
		}
	}
}
