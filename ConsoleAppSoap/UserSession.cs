using DocsVision.Platform.ObjectManager;


namespace ConsoleAppSoap
{
    class UserSession
    {
        public UserSession CreateUserSession()
        {
            // Создаем экземпляр менеджера сессий
            SessionManager sessionManager = SessionManager.CreateInstance();


            // SERVERNAME - имя сервера Docsvision
            // USERNAME и PASSWORD - данные учетной записи для подключения к серверу Docsvision
            string connectionString = "ConnectAddress=http://{SERVERNAME}/DocsVision/StorageServer/StorageServerService.asmx;UserName={USERNAME};Password={PASSWORD}";

            // Передаем менеджеру сессий параметры подключения к серверу (описание см. по ссылке)
            sessionManager.Connect(connectionString);

            // Создаем сессию пользователя
            UserSession userSession = sessionManager.CreateSession();

            return userSession;
        }

    }
}
