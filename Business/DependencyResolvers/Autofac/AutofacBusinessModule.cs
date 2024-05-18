using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System.Reflection;
using Module = Autofac.Module;

namespace Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
    {

		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<AdvertManager>().As<IAdvertService>().SingleInstance();
			builder.RegisterType<EfAdvertDal>().As<IAdvertDal>().SingleInstance();

			builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
			builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();

			builder.RegisterType<DistrictManager>().As<IDistrictService>().SingleInstance();
			builder.RegisterType<EfDistrictDal>().As<IDistrictDal>().SingleInstance();

			builder.RegisterType<GeneralSettingsManager>().As<IGeneralSettingsService>().SingleInstance();
			builder.RegisterType<EfGeneralSettingsDal>().As<IGeneralSettingsDal>().SingleInstance();

			builder.RegisterType<ImageManager>().As<IImageService>().SingleInstance();
			builder.RegisterType<EfImageDal>().As<IImageDal>().SingleInstance();

			builder.RegisterType<NeighbourhoodManager>().As<INeighbourhoodService>().SingleInstance();
			builder.RegisterType<EfNeighbourhoodDal>().As<INeighbourhoodDal>().SingleInstance();

			builder.RegisterType<SituationManager>().As<ISituationService>().SingleInstance();
			builder.RegisterType<EfSituationDal>().As<ISituationDal>().SingleInstance();

			builder.RegisterType<TypeManager>().As<ITypeService>().SingleInstance();
			builder.RegisterType<EfTypeDal>().As<ITypeDal>().SingleInstance();

			builder.RegisterType<UserAdminManager>().As<IUserAdminService>().SingleInstance();
			builder.RegisterType<EfUserAdminDal>().As<IUserAdminDal>().SingleInstance();

			var assembly = Assembly.GetExecutingAssembly();
			builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
				.EnableInterfaceInterceptors(new ProxyGenerationOptions()
				{
					Selector = new AspectInterceptorSelector()
				}).SingleInstance();

		}





	}
}
