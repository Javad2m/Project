using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dto;

public class CommentDTO
{
    public int Id { get; set; }

    public string? CommentText { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int ExpertId { get; set; }
    public Expert Expert { get; set; }

    public int Score { get; set; }
  
}
