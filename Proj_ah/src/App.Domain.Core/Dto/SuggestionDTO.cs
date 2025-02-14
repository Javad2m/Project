using App.Domain.Core.Entities;
using App.Domain.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dto;

public class SuggestionDTO
{

    public int Id { get; set; }

    public string? Descripsion { get; set; }
    public int RequestId { get; set; }
    public Request? Request { get; set; }

    public int ExpertId { get; set; }
    public Expert? Expert { get; set; }
    public float Amount { get; set; }
    public bool? IsWinner { get; set; }


    public DateTime? SuggestedDo { get; set; }


    public SuggestionStatusEnum? Status { get; set; }
}
