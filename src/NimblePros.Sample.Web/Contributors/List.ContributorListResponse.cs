using NimblePros.Sample.Web.ContributorEndpoints;

namespace NimblePros.Sample.Web.Endpoints.ContributorEndpoints;

public class ContributorListResponse
{
  public List<ContributorRecord> Contributors { get; set; } = new();
}