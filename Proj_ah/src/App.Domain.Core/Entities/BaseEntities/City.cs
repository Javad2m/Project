using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities.BaseEntities;

public class City
{
    public int Id { get; set; }
    public string Title { get; set; }

    public List<Customer>? Customers { get; set; }
    public List<Expert>? Experts { get; set; }
}
