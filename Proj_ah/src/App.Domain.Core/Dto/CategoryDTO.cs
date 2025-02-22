using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dto;

public class CategoryDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public IFormFile? ImagePath { get; set; }
    public List<SubCategory>? SubCategories { get; set; }

}
