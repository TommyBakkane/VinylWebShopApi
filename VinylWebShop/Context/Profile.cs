namespace VinylWebShop.Context
{
    public class Profile
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty ;
        public bool IsAdmin { get; set; }

    }
}
