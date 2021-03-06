﻿using Heroes.Icons;
using HeroesMatchTracker.Data.Models.Replays;
using HeroesMatchTracker.Data.Queries.Replays;

namespace HeroesMatchTracker.Core.ViewModels.RawData
{
    public class RawMatchTeamExperienceViewModel : RawDataViewModelBase<ReplayMatchTeamExperience>
    {
        public RawMatchTeamExperienceViewModel(IRawDataQueries<ReplayMatchTeamExperience> iRawDataQueries, IHeroesIcons heroesIcons)
            : base(iRawDataQueries, heroesIcons)
        { }
    }
}
