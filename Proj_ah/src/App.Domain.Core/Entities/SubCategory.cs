using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities;

public class SubCategory
{

    public int Id { get; set; }

    public string Title { get; set; }
    public string? ImagePath { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public List<ServiceSubCategory>? ServiceSubCategories { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatAt { get; set; }
    public bool IsDeleted { get; set; } = false;
}
