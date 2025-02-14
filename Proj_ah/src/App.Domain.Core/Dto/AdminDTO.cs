using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dto;

public class AdminDTO
{
    public int Id { get; set; }
    public string?FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ImagePath { get; set; }
    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public float? Wallet { get; set; }



}
