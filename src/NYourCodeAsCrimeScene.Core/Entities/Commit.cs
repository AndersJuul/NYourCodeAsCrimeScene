using System;
using NYourCodeAsCrimeScene.SharedKernel;
using NYourCodeAsCrimeScene.SharedKernel.Interfaces;

namespace NYourCodeAsCrimeScene.Core.Entities
{
    public class Commit : BaseEntity, IAggregateRoot
    {
        public Commit(string commitId, in DateTime date) : this()
        {
            CommitId = commitId;
            Date = date;
        }

        private Commit()
        {
        }

        public string CommitId { get; set; }
        public DateTime Date { get; set; }

        public Project Project { get; set; }
    }
}