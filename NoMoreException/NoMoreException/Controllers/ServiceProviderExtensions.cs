using System;

namespace NoMoreException.Controllers
{
    public static class ServiceProviderExtensions
    {
        public static T Get<T>(this IServiceProvider serviceProvider) => (T)serviceProvider.GetService(typeof(T).BaseType);
    }
}
