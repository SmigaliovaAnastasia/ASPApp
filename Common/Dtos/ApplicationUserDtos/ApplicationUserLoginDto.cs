using System.ComponentModel.DataAnnotations;

namespace ASPApp.Common.Dtos.ApplicationUserDtos
{ 
    public class ApplicationUserLoginDto 
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
