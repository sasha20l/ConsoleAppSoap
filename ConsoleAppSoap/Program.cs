using System;
using System.Data.Entity.Core.Objects;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using DocsVision.Platform.ObjectManager;

namespace ConsoleAppSoap
{
    class Program
    {
        static void Main(string[] args)
        {
            UserSession userSession = new UserSession();
            userSession = userSession.CreateUserSession();

            ObjectContextCl objectContext = new ObjectContextCl();
            ObjectContext objectcontext = objectContext.CreateObjectContext(userSession);

            CreateCardApi createCardApi = new CreateCardApi();
            CardData card = createCardApi.createCard(userSession);


            CreateCardObjectContext createCardObjectContext = new CreateCardObjectContext(objectcontext);
            IDocumentService documentService = createCardObjectContext.documentService;
            ITaskService taskService = createCardObjectContext.taskService;
            Document document = createCardObjectContext.document;
            Task taks = createCardObjectContext.taks;


        }
    }
}
