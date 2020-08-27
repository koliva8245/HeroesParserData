﻿using System;

namespace HeroesMatchTracker.Core.Models.ReplayParser
{
    [Flags]
    public enum HeroesHostStatuses
    {
        Success = 0,
        Duplicate = 1 << 0,
        Failed = 1 << 1,
        UploadError = 1 << 2,
        Maintenance = 1 << 3,
        Uploading = 1 << 4,
        FileNotFound = 1 << 5,
    }
}