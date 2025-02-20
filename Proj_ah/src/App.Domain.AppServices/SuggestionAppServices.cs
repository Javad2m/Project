using App.Domain.Core.Contracts.AppServices;
using App.Domain.Core.Contracts.Services;
using App.Domain.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices;

public class SuggestionAppServices : ISuggestionAppServices
{
    private readonly ISuggestionServices _suggestionServices;

    public SuggestionAppServices(ISuggestionServices suggestionServices)
    {
        _suggestionServices = suggestionServices;
    }

    public async Task<bool> CreateSuggestion(SuggestionDTO model, CancellationToken cancellationToken)
     => await _suggestionServices.CreateSuggestion(model, cancellationToken);

    public async Task DeleteSuggestionById(int id, CancellationToken cancellationToken)
     => await _suggestionServices.DeleteSuggestionById(id, cancellationToken);

    public async Task<List<SuggestionDTO>> GetAllSuggestion(CancellationToken cancellationToken)
    => await _suggestionServices.GetAllSuggestion(cancellationToken);

    public async Task<bool> UpdateSuggestion(SuggestionDTO model, CancellationToken cancellationToken)
    => await _suggestionServices.UpdateSuggestion(model, cancellationToken);

}
