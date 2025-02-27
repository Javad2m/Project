using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dto;

public class CommentAcceptDto
{
    public int Id { get; set; }
    public bool IsAccept { get; set; } = false;
}
