using System;
using NYourCodeAsCrimeScene.Core.Entities;

namespace NYourCodeAsCrimeScene.UnitTests
{
    // Learn more about test builders:
    // https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
    public class CommitBuilder
    {
        private Commit _commit = null;

        public CommitBuilder Id(int id)
        {
            _commit.Id = id;
            return this;
        }

        public CommitBuilder WithDefaultValues()
        {
            _commit = new Commit( "CommitId-1", DateTime.Now );

            return this;
        }

        public Commit Build() => _commit;
    }
}
