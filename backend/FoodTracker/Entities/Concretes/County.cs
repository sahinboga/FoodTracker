using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
	public class County:IEntity
	{
		public int Id { get; set; }
		public int CityId { get; set; }
		public string CountyName { get; set; }
	}
}
