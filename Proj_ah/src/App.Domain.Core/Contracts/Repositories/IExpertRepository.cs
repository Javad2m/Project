﻿using App.Domain.Core.Dto;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repositories;

public interface IExpertRepository
{
    Task<bool> CreateExpert(ExpertDTO model, CancellationToken cancellationToken);
    Task<bool> DeleteExpertById(int id, CancellationToken cancellationToken);
    Task<List<Expert>> GetAllExperts(CancellationToken cancellationToken);
    Task UpdateExpert(ExpertDTO model, CancellationToken cancellationToken);

    Task<ExpertDTO>? GetExpertById(int id, CancellationToken cancellationToken);
}
