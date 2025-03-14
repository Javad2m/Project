﻿using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dto;

public class SubCategoryDTO
{
    public int Id { get; set; }

    public string? Title { get; set; }
    public string? ImagePath { get; set; }

    public DateTime CreatAt { get; set; }
    public string CategoryName { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public List<ServiceSubCategory>? ServiceSubCategories { get; set; }

}
