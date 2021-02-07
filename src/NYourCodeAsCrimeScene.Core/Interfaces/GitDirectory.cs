using System;
using System.Collections.Generic;

namespace NYourCodeAsCrimeScene.Core.Interfaces
{
    public struct GitDirectory
    {
        public String name;
        public List<GitDirectory> subDirs;
        public List<GitFileData> files;
    }
}