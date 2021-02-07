using System;
using System.Collections.Generic;

namespace NYourCodeAsCrimeScene.Core.Services
{
    public struct Directory
    {
        public String name;
        public List<Directory> subDirs;
        public List<FileData> files;
    }
}