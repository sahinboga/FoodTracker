using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstracts;
using Business.Concretes;
using Core.Utilities.Interceptors;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule:Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
			builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

			builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
			builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();

			builder.RegisterType<CountyManager>().As<ICountyService>().SingleInstance();
			builder.RegisterType<EfCountyDal>().As<ICountyDal>().SingleInstance();

			builder.RegisterType<RestaurantManager>().As<IRestaurantService>().SingleInstance();
			builder.RegisterType<EfRestaurantDal>().As<IRestaurantDal>().SingleInstance();

			builder.RegisterType<RestaurantImageManager>().As<IRestaurantImageService>().SingleInstance();
			builder.RegisterType<EfRestaurantImageDal>().As<IRestaurantImageDal>().SingleInstance();

			var assembly = System.Reflection.Assembly.GetExecutingAssembly();

			builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
				.EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
				{
					Selector = new AspectInterceptorSelector()
				}).SingleInstance();
		}
	}
}
