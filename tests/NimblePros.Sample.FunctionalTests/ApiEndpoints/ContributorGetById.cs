using Ardalis.HttpClientTestExtensions;
using NimblePros.Sample.Infrastructure.Data;
using NimblePros.Sample.Web.ContributorEndpoints;
using NimblePros.Sample.Web.Endpoints.ContributorEndpoints;
using Xunit;

namespace NimblePros.Sample.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class ContributorGetById(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task ReturnsSeedContributorGivenId1()
  {
    var result = await _client.GetAndDeserializeAsync<ContributorRecord>(GetContributorByIdRequest.BuildRoute(1));

    Assert.Equal(1, result.Id);
    Assert.Equal(SeedData.Contributor1.Name, result.Name);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenId1000()
  {
    string route = GetContributorByIdRequest.BuildRoute(1000);
    _ = await _client.GetAndEnsureNotFoundAsync(route);
  }
}
