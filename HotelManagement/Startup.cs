using System.Reflection;
using Unity;
using Prism.Modularity;

namespace HotelManagement
{
    public class Startup //: IModule
    {
        private static IUnityContainer _container;

        public Startup(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            //_container.RegisterTypes(AllClasses.FromAssemblies(Assembly.Load("FxClient.Services.UserSettings")),
            //    WithMappings.FromAllInterfacesInSameAssembly,
            //    WithName.Default, WithLifetime.Transient);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
