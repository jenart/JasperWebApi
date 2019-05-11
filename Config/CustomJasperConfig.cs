using Jasper;

namespace JasperWebApi.Config
{
    public class CustomJasperConfig : JasperRegistry
    {
        public CustomJasperConfig()
        {
            Handlers.Discovery(x =>
            {
                // Include candidate actions by a user supplied
                // type filter
                //x.IncludeTypes(t => t.IsInNamespace("MyApp.Handlers"));

                // Include candidate classes by suffix
                x.IncludeClassesSuffixedWith("ReadModelManager");

                // Include a specific handler class with a generic argument
                //x.IncludeType<SimpleHandler>();
            });


            // Also exposes Lamar specific registrations
            // and functionality
            Services.Scan(s =>
            {
                s.TheCallingAssembly();
                s.WithDefaultConventions();
            });

//           Services.For<ILogger>().Use<LoggerInstance<>>();
//           Services.ForSingletonOf<ILogger>().Add(NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger());
        }
    }
}