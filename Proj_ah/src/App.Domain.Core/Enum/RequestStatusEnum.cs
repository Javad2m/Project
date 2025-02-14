using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Enum;

public enum RequestStatusEnum
{


    CheckingAndWaitingExpert = 1,

    RegisteredByExpert = 2,

    Done = 3,

    

}
