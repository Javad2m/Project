using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities;

public class ServiceSubCategory
{


    public int Id { get; set; }

    public string Title { get; set; }
    public string? ImagePath { get; set; }

    public int SubCategoryId { get; set; }
    public SubCategory SubCategory { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatAt { get; set; }
    public List<Request>? Requests { get; set; }

    public List<Expert>? Experts { get; set; }
    public bool IsDeleted { get; set; } = false;
}
