﻿using Ardalis.Result;

namespace NimblePros.Sample.UseCases.Contributors.Create;

/// <summary>
/// Create a new Contributor.
/// </summary>
/// <param name="Name"></param>
public record CreateContributorCommand(string Name) : Ardalis.SharedKernel.ICommand<Result<int>>;
