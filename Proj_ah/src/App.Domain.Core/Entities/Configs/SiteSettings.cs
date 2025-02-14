using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.Configs;

public class SiteSettings
{
    public Connectionstrings ConnectionStrings { get; set; }
}

public class Connectionstrings
{
    public string SqlConnection { get; set; }
}



