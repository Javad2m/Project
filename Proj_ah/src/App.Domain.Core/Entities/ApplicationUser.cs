using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities;

public class ApplicationUser : IdentityUser<int>
{
    public Admin? Admin { get; set; }
    public Customer? Customer { get; set; }
    public Expert? Expert { get; set; }
}
