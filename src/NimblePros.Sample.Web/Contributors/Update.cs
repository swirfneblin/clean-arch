﻿using NimblePros.Sample.Core.ContributorAggregate;
using Ardalis.SharedKernel;
using FastEndpoints;
using NimblePros.Sample.Web.Endpoints.ContributorEndpoints;
using NimblePros.Sample.UseCases.Contributors.Create;
using NimblePros.Sample.UseCases.Contributors.Update;
using MediatR;
using Ardalis.Result;
using NimblePros.Sample.UseCases.Contributors.Get;

namespace NimblePros.Sample.Web.ContributorEndpoints;

/// <summary>
/// Update an existing Contributor.
/// </summary>
/// <remarks>
/// Update an existing Contributor by providing a fully defined replacement set of values.
/// See: https://stackoverflow.com/questions/60761955/rest-update-best-practice-put-collection-id-without-id-in-body-vs-put-collecti
/// </remarks>
public class Update(IMediator _mediator)
  : Endpoint<UpdateContributorRequest, UpdateContributorResponse>
{
  public override void Configure()
  {
    Put(UpdateContributorRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdateContributorRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdateContributorCommand(request.Id, request.Name!));

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetContributorQuery(request.ContributorId);

    var queryResult = await _mediator.Send(query);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      var dto = queryResult.Value;
      Response = new UpdateContributorResponse(new ContributorRecord(dto.Id, dto.Name));
      return;
    }
  }
}
