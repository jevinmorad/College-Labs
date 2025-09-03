namespace HospitalManagementSystem
{
    public class CommonVariable
    {
        private static IHttpContextAccessor _HttpContextAccessor;

        static CommonVariable()
        {
            _HttpContextAccessor = new HttpContextAccessor();
        }
        
        
        public static int? UserID()
        {
        
            if (_HttpContextAccessor.HttpContext.Session.GetString("UserID") == null)
            {
                return null;
            }
        
            return _HttpContextAccessor.HttpContext.Session.GetInt32("UserID");
        }
        
        public static string UserName()
        {
            if (_HttpContextAccessor.HttpContext.Session.GetString("UserName") == null)
            {
                return null;
            }
        
            return _HttpContextAccessor.HttpContext.Session.GetString("UserName");
        }
        
        public static string Email()
        {
            if (_HttpContextAccessor.HttpContext.Session.GetString("Email") == null)
            {
                return null;
            }
            return _HttpContextAccessor.HttpContext.Session.GetString("Email");
        }

        public static string ProfilePhoto()
        {
            if (_HttpContextAccessor.HttpContext.Session.GetString("ProfilePhoto") == null)
            {
                return "/images/default-profile.png";
            }
            return _HttpContextAccessor.HttpContext.Session.GetString("ProfilePhoto");
        }

        public static string MobileNo()
        {
            if (_HttpContextAccessor.HttpContext.Session.GetString("MobileNo") == null)
            {
                return null;
            }
            return _HttpContextAccessor.HttpContext.Session.GetString("MobileNo");
        }
    }
}
