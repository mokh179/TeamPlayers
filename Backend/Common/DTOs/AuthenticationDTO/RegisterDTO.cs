
namespace Common.DTOs.AuthenticationDTO
{
    public class RegisterDTO
    {
        [Required, MaxLength(50)]
        public string Firstname { get; set; }
        [Required, MaxLength(50)]
        public string Lastname { get; set; }
        [Required, MaxLength(120)]
        public string Username { get; set; }
        [Required, MaxLength(120)]
        public string Email { get; set; }
        [Required, MaxLength(256)]
        public string Password { get; set; }
        [Required, MaxLength(256), Compare("Password", ErrorMessage = "Password didn't match")]
        public string cPassword { get; set; }
    }
}
