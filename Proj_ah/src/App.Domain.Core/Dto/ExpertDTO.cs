using App.Domain.Core.Entities.BaseEntities;
using App.Domain.Core.Entities;
using App.Domain.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dto;

public class ExpertDTO
{

    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }

    public string? ImagePath { get; set; }



    public int? CityId { get; set; }
    public City? City { get; set; }


    public List<Suggestion>? Suggestions { get; set; }
    public string? Description { get; set; }

    public List<ServiceSubCategory>? Skills { get; set; }

    public GenderEnum? Gender { get; set; }
    public int ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public bool IsActive { get; set; } = false;

    public float Wallet { get; set; }


}
