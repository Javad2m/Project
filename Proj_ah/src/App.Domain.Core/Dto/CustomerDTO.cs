using App.Domain.Core.Entities.BaseEntities;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Dto;

public class CustomerDTO
{

    public int Id { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }
    public string? Mail { get; set; }
    public string? ImagePath { get; set; }
    public int? CityId { get; set; }
    public City? City { get; set; }
    public List<Request>? Requests { get; set; }

    public List<Comment>? Comments { get; set; }

    public int ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    public float Wallet { get; set; }



}
