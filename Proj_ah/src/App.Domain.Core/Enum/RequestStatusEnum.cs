using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Enum;

public enum RequestStatusEnum
{

    [Display(Name = "در ارنتظار بررسی کارشناس")]
    CheckingAndWaitingExpert = 1,

    [Display(Name = "تایید شده توسط کارشناس")]
    RegisteredByExpert = 2,

    [Display(Name = "انجام شده")]
    Done = 3,

    

}
