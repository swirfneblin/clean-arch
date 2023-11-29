using NimblePros.Sample.UseCases.Contributors;
using NimblePros.Sample.UseCases.Contributors.List;

namespace NimblePros.Sample.Infrastructure.Data.Queries;

public class FakeListContributorsQueryService : IListContributorsQueryService
{
  public Task<IEnumerable<ContributorDTO>> ListAsync()
  {
    List<ContributorDTO> result = 
        [new ContributorDTO(1, "Fake Contributor 1"), 
        new ContributorDTO(2, "Fake Contributor 2")];

    return Task.FromResult(result.AsEnumerable());
  }
}
