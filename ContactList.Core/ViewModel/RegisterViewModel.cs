using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Core.ViewModel
{
    public class RegisterViewModel
    {

        [Display(Name = "نام کاربری")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        public string Name { get; set; }


        [Display(Name = "ایمیل")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        [EmailAddress(ErrorMessage = "لطفا ایمیل را به درستی وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "رمز عبور")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "شماره تلفن")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        public string PhoneNumber { get; set; }

    }
}
