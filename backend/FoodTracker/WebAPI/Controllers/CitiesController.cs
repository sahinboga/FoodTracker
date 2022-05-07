using Business.Abstracts;
using Core.Extensions;
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
	public class CitiesController : ControllerBase
	{
		ICityService _cityService;

		public CitiesController(ICityService cityService)
		{
			_cityService = cityService;
		}

		[HttpGet("getallcities")]
		public IActionResult GetAll()
		{
			return this.ResponseResult(_cityService.GetAll());
		}
	}
}
