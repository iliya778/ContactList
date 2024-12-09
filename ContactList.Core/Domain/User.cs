using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Core.Domain
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "نام")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        public string Name { get; set; }

        [Display(Name = "شماره تلفن")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        public string PhoneNumber { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "رمز عبور")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string? ActiveCode { get; set; }
        public bool isActive { get; set; }

        [Display(Name = "ادمین")]
        public bool IsAdmin { get; set; }

    }
}
