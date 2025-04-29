namespace JwtAuthDemo.Model
{
    // model class for user credentials
    public class LoginModel
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
