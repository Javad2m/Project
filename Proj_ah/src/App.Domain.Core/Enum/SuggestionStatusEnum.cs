using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Enum;

public enum SuggestionStatusEnum
{
    [Display(Name = "درانتظارتاییدمشتری")]
    AwaitingReview = 1,
    [Display(Name = "تاییدشده")]
    Accept = 2,
    [Display(Name = "ردشده")]
    Reject = 3,



}
