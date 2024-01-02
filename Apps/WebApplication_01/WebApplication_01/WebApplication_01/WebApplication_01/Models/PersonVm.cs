using System.ComponentModel.DataAnnotations;

namespace WebApplication_01.Models
{
    public class PersonVm : BaseVm
    {
        [Display(Name = "کد")]
        public int Id { get; set; }

        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

    }
}
