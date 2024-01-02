using System.ComponentModel.DataAnnotations;

namespace WebApplication_01.Models
{
    public class LoginVm
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsRememberMe { get; set; }
    }
}
