using App.Domain.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities;

public class Customer
{

    public int Id { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string Mail { get; set; }
    public string? ImagePath { get; set; }

    public float Wallet { get; set; }

    public bool IsActive { get; set; } = false;

    public int ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    public int? CityId { get; set; }
    public City? City { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<Comment>? Comments { get; set; }

    public List<Request>? Requests { get; set; }

    public bool IsDeleted { get; set; } = false;

}
