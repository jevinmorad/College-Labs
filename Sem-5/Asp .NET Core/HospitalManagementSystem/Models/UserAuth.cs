namespace HospitalManagementSystem.Models
{
    public class UserAuth
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public UserAuth()
        {
            Username = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            RememberMe = false;
        }
        
        public UserAuth(string? username, string email, string password, bool rememberMe)
        {
            Username = username ?? string.Empty;
            Email = email;
            Password = password;
            RememberMe = rememberMe;
        }
    }
}
