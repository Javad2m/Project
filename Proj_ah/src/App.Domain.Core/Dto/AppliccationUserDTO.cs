using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dto;

public class AppliccationUserDTO
{

    [Required(ErrorMessage = "نام الزامی است.")]
    [StringLength(100, ErrorMessage = "نام نباید بیشتر از 100 کاراکتر باشد.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "نام خانوادگی الزامی است.")]
    [StringLength(100, ErrorMessage = "نام خانوادگی نباید بیشتر از 100 کاراکتر باشد.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "ایمیل الزامی است.")]
    [EmailAddress(ErrorMessage = "فرمت ایمیل وارد شده صحیح نیست.")]
    public string? Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "رمز عبور الزامی است.")]
    [MinLength(6, ErrorMessage = "رمز عبور باید حداقل 6 کاراکتر باشد.")]
    [MaxLength(100, ErrorMessage = "رمز عبور نباید بیشتر از 100 کاراکتر باشد.")]
    public string? Password { get; set; } = string.Empty;
   
    public string? Role { get; set; }
}
