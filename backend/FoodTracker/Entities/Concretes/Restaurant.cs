using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
	public class Restaurant:IEntity
	{
		public int Id { get; set; }
		public int CategoryId { get; set; }
		public string RestaurantName { get; set; }
		public int CountyId { get; set; }
		public DateTime FoundedDate { get; set; }
	}
}
