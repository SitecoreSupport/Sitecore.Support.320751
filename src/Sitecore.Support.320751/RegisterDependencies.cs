using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.XA.Feature.Maps.Repositories;

namespace Sitecore.Support
{
  public class RegisterDependencies : IServicesConfigurator
  {
    public void Configure(IServiceCollection serviceCollection)
    {
      serviceCollection.AddTransient<IMapsRepository, Sitecore.Support.XA.Feature.Maps.Repositories.MapsRepository>();
    }
  }
}
