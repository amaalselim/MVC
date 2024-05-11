using System.ComponentModel.DataAnnotations;

namespace languages.ViewModel
{
    public class LogIn
    {
        [Required] 
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public bool RememberMe { get; set; }
    }
}
