﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dto;

public class ApplicationUserLoginDTO
{
    public string Email { get; set; }
    public string Password { get; set; }
}
