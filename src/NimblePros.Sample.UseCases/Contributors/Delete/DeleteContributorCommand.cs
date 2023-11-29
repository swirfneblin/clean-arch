﻿using Ardalis.Result;
using Ardalis.SharedKernel;

namespace NimblePros.Sample.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
