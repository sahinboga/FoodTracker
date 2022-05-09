using Business.Abstracts;
using Core.Extensions;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RestaurantImagesController : ControllerBase
	{
		IRestaurantImageService _restaurantImageService;

		public RestaurantImagesController(IRestaurantImageService restaurantImageService)
		{
			_restaurantImageService = restaurantImageService;
		}

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return this.ResponseResult(_restaurantImageService.GetAll());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return this.ResponseResult(_restaurantImageService.GetById(id));
        }

        [HttpGet("getfirstimagebyrestaurantid")]
        public IActionResult GetFirstOrDefaultByCarId(int restaurantId)
        {
            return this.ResponseResult(_restaurantImageService.GetFirstOrDefaultByCarId(restaurantId));
        }

        [HttpGet("getrestaurantimagesbyrestaurantid")]
        public IActionResult GetCarImagesByCarId(int restaurantId)
        {
            return this.ResponseResult(_restaurantImageService.GetRestaurantImagesByRestaurantId(restaurantId));
        }


        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile imageFile, [FromForm] RestaurantImage restaurantImage)
        {
            return this.ResponseResult(_restaurantImageService.UploadRestaurantImage(imageFile, restaurantImage));
        }

        [HttpPost("update")]
        public IActionResult Update(RestaurantImage restaurantImage)
        {
            return this.ResponseResult(_restaurantImageService.Update(restaurantImage));
        }
    }
}
