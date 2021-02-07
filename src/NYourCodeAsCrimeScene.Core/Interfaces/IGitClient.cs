﻿using System.Collections.Generic;
using System.Threading.Tasks;
using NYourCodeAsCrimeScene.Core.Services;

namespace NYourCodeAsCrimeScene.Core.Interfaces
{
    public interface IGitClient
    {
        Task<IEnumerable<CommitDto>> GetCommits(string projectName, string projectPath, string[] fileExt);
    }
}