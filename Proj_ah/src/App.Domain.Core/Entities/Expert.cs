using App.Domain.Core.Entities.BaseEntities;
using App.Domain.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities;

public class Expert
{


    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string Email { get; set; }

    public string? ImagePath { get; set; }

    public float Wallet { get; set; }

    public bool IsActive { get; set; } = false;

    public int? CityId { get; set; }
    public City? City { get; set; }

    public DateTime CreatedAt { get; set; }

    public int ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    public string? Description { get; set; }

    public List<ServiceSubCategory>? Skills { get; set; }

    public GenderEnum? Gender { get; set; }

    public List<Suggestion>? Suggestions { get; set; }

}
