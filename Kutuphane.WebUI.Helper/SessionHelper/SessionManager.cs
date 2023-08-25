using Kutuphane.Core.DTO;
using Microsoft.AspNetCore.Http;


namespace Kutuphane.WebUI.Helper.SessionHelper
{
    public class SessionManager
    {
      
        public static LoginDto? LoggedUser 
        {
            get => AppHttpContext.Current.Session.GetObject<LoginDto>("LoginDTO");
            set => AppHttpContext.Current.Session.SetObject("LoginDTO", value);
        }

       
    }
}
