using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManyToManyEF
{
    public class File
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public string FullPath { get; set; }

        //[ForeignKey("Folder")]
        public Guid FolderId { get; set; }
        //public Folder Folder { get; set; }
    }
}
