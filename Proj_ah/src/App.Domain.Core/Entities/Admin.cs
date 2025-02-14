using App.Domain.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities;

public class Admin
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? ImagePath { get; set; }
    public string Email { get; set; }

    public float Wallet { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; } = true;
    public int ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public bool IsDeleted { get; set; } = false;
}
