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
	public class CountiesController : ControllerBase
	{
		ICountyService _countyService;

		public CountiesController(ICountyService countyService)
		{
			_countyService = countyService;
		}

		[HttpGet("getallcounties")]
		public IActionResult GetAll()
		{
			return this.ResponseResult(_countyService.GetAll());
		}

		[HttpGet("getcountiesbycity")]
		public IActionResult GetCountyByCity(int cityId)
		{
			return this.ResponseResult(_countyService.GetCountyByCity(cityId));
		}

		[HttpGet("getbyid")]
		public IActionResult GetCountyById(int countyId)
		{
			return this.ResponseResult(_countyService.GetById(countyId));
		}
	}
}
