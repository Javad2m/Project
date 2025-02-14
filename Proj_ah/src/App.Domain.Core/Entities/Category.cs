using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities;

public class Category
{

    public int Id { get; set; }
    public string Title { get; set; }
    public string? ImagePath { get; set; }
    public List<SubCategory>? SubCategories { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatAt { get; set; }
}
