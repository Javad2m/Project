using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.BaseEntities;

public class Image
{
    public int Id { get; set; }
    public string Path { get; set; }

    public int? RequestId { get; set; }
    public Request? Request { get; set; }
}
