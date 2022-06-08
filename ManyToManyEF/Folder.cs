using System;

namespace ManyToManyEF
{
    public class Folder
    {
        public Guid FolderId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
