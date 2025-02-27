using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Http;
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
    public IFormFile? ImagePath { get; set; }
    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public float? Wallet { get; set; }

    public bool IsDeleted { get; set; } = false;

    public int ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }



}
