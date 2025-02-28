using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dto;

public class ApplicationUserLoginDTO
{

    [Required(ErrorMessage = "نام کاربری الزامی است.")]
    [EmailAddress(ErrorMessage = "فرمت ایمیل وارد شده صحیح نیست.")]
    public string Email { get; set; }


    [Required(ErrorMessage = "رمز عبور الزامی است.")]
    [MinLength(6, ErrorMessage = "رمز عبور باید حداقل 6 کاراکتر باشد.")]
    public string Password { get; set; }
}
