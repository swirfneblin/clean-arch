using Ardalis.Result;
using Ardalis.SharedKernel;

namespace NimblePros.Sample.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
