﻿using HeroesMatchTracker.Infrastructure.Database.Contexts;
using HeroesMatchTracker.Shared.Entities;

namespace HeroesMatchTracker.Core.Database.HeroesReplays
{
    public interface IReplayPlayerToonRepository
    {
        bool IsExists(HeroesReplaysDbContext context, ReplayPlayerToon replayPlayerToon);

        long? GetPlayerId(HeroesReplaysDbContext context, ReplayPlayerToon replayPlayerToon);
    }
}