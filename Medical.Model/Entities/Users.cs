namespace Medical.Model.Entities
{
    /// <summary>
    /// The user class
    /// </summary>
    public class Users
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public bool IsApprove { get; set; }
        public string Mobile { get; set; }
        public string PasswordExpiredDate { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Users"/> class
        /// </summary>
        public Users()
        {
            UserName = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            IsApprove = true;
            Password = string.Empty;
        }
    }
}
