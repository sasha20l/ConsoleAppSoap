
using System.Data.Entity.Core.Objects;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using DocsVision.Platform.ObjectManager;

namespace ConsoleAppSoap
{
    class CreateCardObjectContext
    {
        private static ObjectContext objectContext;

        public CreateCardObjectContext(ObjectContext _objectContext)
        {
            objectContext = _objectContext;
        }

        public static IDocumentService documentService = objectContext.GetService<IDocumentService>();
        public static ITaskService taskService = objectContext.GetService<ITaskService>();

        // Создаем экземпляр карточки типа Документ
        public Document document = documentService.CreateDocument();

        // Создаем экземпляр карточки типа Задание
        public Task taks = taskService.CreateTask();

        // Сохраняем все изменения контекста объектов
        objectContext.AcceptChanges();

    }
}
