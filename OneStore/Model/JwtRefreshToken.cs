namespace OneStore.Model
{
    public class JwtRefreshToken
    {
        public int Id { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public int UserId { get; set; }
        public DateTime ExpireAt { get; set; }
        public bool IsRevoked { get; set; }
    }
}
