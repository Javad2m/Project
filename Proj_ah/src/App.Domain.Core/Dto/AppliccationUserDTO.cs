using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dto;

public class AppliccationUserDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Email { get; set; } = string.Empty;
    public string? Password { get; set; } = string.Empty;
   
    public string? Role { get; set; }
}
