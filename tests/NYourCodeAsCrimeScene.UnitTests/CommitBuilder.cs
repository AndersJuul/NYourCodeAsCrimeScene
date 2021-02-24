﻿using System;
using NYourCodeAsCrimeScene.Core.Entities;

namespace NYourCodeAsCrimeScene.UnitTests
{
    // Learn more about test builders:
    // https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
    public class CommitBuilder
    {
        private GitCommit _gitCommit = null;

        public CommitBuilder Id(int id)
        {
            _gitCommit.Id = id;
            return this;
        }

        public CommitBuilder WithDefaultValues()
        {
            _gitCommit = new GitCommit( "CommitId-1", DateTime.Now );

            return this;
        }

        public GitCommit Build() => _gitCommit;
    }
}
