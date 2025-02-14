using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dto;

public class ServiceSubCategoryDTO
{

    public int Id { get; set; }

    public string? Title { get; set; }
    public string? ImagePath { get; set; }

    public int SubCategoryId { get; set; }
    public SubCategory? SubCategory { get; set; }
    public List<Request>? Requests { get; set; }

    public List<Expert>? Experts { get; set; }

}
