using System;
using DocsVision.Platform.ObjectManager;

namespace ConsoleAppSoap
{
    class CreateCardApi
    {
        public CardData createCard(UserSession userSession)
        {

            return userSession.CardManager.CreateCardData(new Guid("B4562DF8-AF19-4D0F-85CA-53A311354D39"));

        }
    }
}
