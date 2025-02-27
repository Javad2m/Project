using App.Domain.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dto;

public class StatusRequestDto
{

    public int Id { get; set; }
    public RequestStatusEnum Status { get; set; }
}
