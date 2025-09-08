namespace HospitalManagementSystem.Models
{
    public class UserAuth
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public UserAuth()
        {
            FirstName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            RememberMe = false;
        }
        
        public UserAuth(string? FirstName, string email, string password, bool rememberMe)
        {
            FirstName = FirstName ?? string.Empty;
            Email = email;
            Password = password;
            RememberMe = rememberMe;
        }
    }
}
