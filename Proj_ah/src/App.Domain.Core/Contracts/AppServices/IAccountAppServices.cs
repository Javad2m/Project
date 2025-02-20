using App.Domain.Core.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppServices;
public interface IAccountAppServices
{

    Task<bool> Login(ApplicationUserLoginDTO model, CancellationToken cancellationToken);
    Task<List<IdentityError>> Register(AppliccationUserDTO model, CancellationToken cancellationToken);
}
