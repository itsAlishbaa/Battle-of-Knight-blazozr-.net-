//using System.ComponentModel.DataAnnotations;

//public class UserAccount
//{
//    [Required(ErrorMessage = "Name is required")]
//    public string FullName { get; set; } = "";

//    [Required]
//    [EmailAddress(ErrorMessage = "Invalid email format (needs @)")]
//    public string Email { get; set; } = "";

//    [Required]
//    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
//    public string Password { get; set; } = "";

//    public string? DOB { get; set; }
//}

namespace blazor_final_pro.Models
{
    public class UserAccount
    {
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        // Personalized game stats
        public int Wins { get; set; } = 0;
        public int Losses { get; set; } = 0;
        public int CurrentLevel { get; set; } = 1;
    }
}