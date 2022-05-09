using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
	public class RestaurantDto:IEntity
	{
		public int Id { get; set; }
		public string RestaurantName { get; set; }
		public string Category { get; set; }
		public string Location { get; set; }
		public DateTime FoundedDate { get; set; }
	}
}
