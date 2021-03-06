using Business.Abstracts;
using Core.Extensions;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RestaurantsController : ControllerBase
	{
		IRestaurantService _restaurantService;

		public RestaurantsController(IRestaurantService restaurantService)
		{
			_restaurantService = restaurantService;
		}

		[HttpGet("getallrestaurants")]
		public IActionResult GetAll()
		{
			return this.ResponseResult(_restaurantService.GetAll());
		}

		[HttpGet("getalldetailrestaurants")]
		public IActionResult GetAllWithDetails()
		{
			return this.ResponseResult(_restaurantService.GetAllWithDetails());
		}

		[HttpGet("getbyid")]
		public IActionResult GetById(int id)
		{
			return this.ResponseResult(_restaurantService.GetById(id));
		}

		[HttpGet("getdetailbyid")]
		public IActionResult GetDetailById(int id)
		{
			return this.ResponseResult(_restaurantService.GetDetailById(id));
		}

		[HttpGet("getallbycategoryid")]
		public IActionResult GetAllByCategoryId(int categoryId)
		{
			return this.ResponseResult(_restaurantService.GetAllByCategoryId(categoryId));
		}

		[HttpGet("getdetailsbycategoryid")]
		public IActionResult GetDetailsByCategoryId(int categoryId)
		{
			return this.ResponseResult(_restaurantService.GetDetailsByCategoryId(categoryId));
		}

		[HttpPost("add")]
		public IActionResult Add(Restaurant restaurant)
		{
			return this.ResponseResult(_restaurantService.Add(restaurant));
		}

		[HttpPost("update")]
		public IActionResult Update(Restaurant restaurant)
		{
			return this.ResponseResult(_restaurantService.Update(restaurant));
		}

		[HttpPost("delete")]
		public IActionResult Delete(Restaurant restaurant)
		{
			return this.ResponseResult(_restaurantService.Delete(restaurant));
		}
	}
}
