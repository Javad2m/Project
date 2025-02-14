using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities;

public class Comment
{
    public int Id { get; set; }

    public string? CommentText { get; set; }
    public DateTime CreatAt { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public bool IsDeleted { get; set; } = false;
    public int ExpertId { get; set; }
    public Expert Expert { get; set; }

    public int Score { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsAccept { get; set; } = false;






}
