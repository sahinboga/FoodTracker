using Business.Concretes;
using DataAccess.Concretes.EntityFramework;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			CityManager cityManager = new CityManager(new EfCityDal());
			foreach (var c in cityManager.GetAll().Data)
			{
				Console.WriteLine(c.CityName);
			}
		}
	}
}
