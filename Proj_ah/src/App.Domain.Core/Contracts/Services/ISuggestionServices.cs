using App.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Services;

public interface ISuggestionServices
{
    Task<bool> CreateSuggestion(SuggestionDTO model, CancellationToken cancellationToken);
    Task<List<SuggestionDTO>> GetAllSuggestion(CancellationToken cancellationToken);
    Task<bool> UpdateSuggestion(SuggestionDTO model, CancellationToken cancellationToken);

    Task DeleteSuggestionById(int id, CancellationToken cancellationToken);

    public Task<bool> ChangeSuggestionStatus(SuggestionStatusDto status, CancellationToken cancellationToken);

}
