
using System.ComponentModel.Design;
using System.Data.Entity.Core.Objects;
using DocsVision.Platform.ObjectManager;

namespace ConsoleAppSoap
{
    class ObjectContextCl
    {
        public ObjectContext CreateObjectContext(UserSession userSession)
        {
            var sessionContainer = new ServiceContainer();
            sessionContainer.AddService(typeof(UserSession), userSession);

            var objectContext = new ObjectContext(sessionContainer);

            var mapperFactoryRegistry = objectContext.GetService<IObjectMapperFactoryRegistry>();
            mapperFactoryRegistry.RegisterFactory(typeof(SystemCardsMapperFactory));
            mapperFactoryRegistry.RegisterFactory(typeof(BackOfficeMapperFactory));


            var serviceFactoryRegistry = objectContext.GetService<IServiceFactoryRegistry>();
            serviceFactoryRegistry.RegisterFactory(typeof(BackOfficeServiceFactory));
            serviceFactoryRegistry.RegisterFactory(typeof(SystemCardsServiceFactory));


            objectContext.AddService<IPersistentStore>(DocsVisionObjectFactory.CreatePersistentStore(new SessionProvider(userSession), null));

            IMetadataProvider metadataProvider = DocsVisionObjectFactory.CreateMetadataProvider(userSession);
            objectContext.AddService<IMetadataManager>(DocsVisionObjectFactory.CreateMetadataManager(metadataProvider, userSession));
            objectContext.AddService<IMetadataProvider>(metadataProvider);

            return objectContext;
        }
    }
}
