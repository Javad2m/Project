using App.Domain.Core.Entities;
using App.Domain.Core.Entities.BaseEntities;
using App.Domain.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dto;

public class RequestDTO
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public string? Description { get; set; }

    public int? ServiceSubCategoryId { get; set; }
    public ServiceSubCategory? ServiceSubCategory { get; set; }

    public List<Suggestion>? Suggestions { get; set; }

    public RequestStatusEnum Status { get; set; }
    public List<Image>? Images { get; set; }


    public DateTime? DoneTime { get; set; }

    public float BasePrice { get; set; }
}
