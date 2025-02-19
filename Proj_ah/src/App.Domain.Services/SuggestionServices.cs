using App.Domain.Core.Contracts.Repositories;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services;

public class SuggestionServices : ISuggestionServices
{

    private readonly ISuggestionRepository _suggestionRepository;

    public SuggestionServices(ISuggestionRepository suggestionRepository)
    {
        _suggestionRepository = suggestionRepository;
    }
    public async Task<bool> CreateSuggestion(SuggestionDTO model, CancellationToken cancellationToken)
      => await _suggestionRepository.CreateSuggestion(model, cancellationToken);

    public async Task DeleteSuggestionById(int id, CancellationToken cancellationToken)
     => await _suggestionRepository.DeleteSuggestionById(id, cancellationToken);

    public async Task<List<SuggestionDTO>> GetAllSuggestion(CancellationToken cancellationToken)
    => await _suggestionRepository.GetAllSuggestion(cancellationToken);

    public async Task<bool> UpdateSuggestion(SuggestionDTO model, CancellationToken cancellationToken)
    => await _suggestionRepository.UpdateSuggestion(model, cancellationToken);
}
