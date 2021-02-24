using System;

namespace NYourCodeAsCrimeScene.Core.Services
{
    public class CommitDto
    {
        public string CommitId { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
    }

    public class FileDto
    {
        public string Name { get; set; }
    }
}