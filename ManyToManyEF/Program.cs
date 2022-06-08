using System;
using System.IO;
using System.Linq;

namespace ManyToManyEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Input the path:");
            //var x = Console.ReadLine();
            //Console.WriteLine(x);
            // C:/Users/Rokas/Desktop/Compliance.AssociatedAccounts

            var path = "C:/Users/Rokas/Desktop/Compliance.AssociatedAccounts";
            
            FilesDbContext filesDbContext = new FilesDbContext();

            // atidaryti direktorija
            // uzrasyti visa info is jos
            // atidaryti kita direktorija
            // vel uzrasyti
            // jei nebera direktoriju breakint

            OpenAllDirectories("C:/Users/Rokas/Desktop/Compliance.AssociatedAccounts/builds");
        }

        public static void OpenAllDirectories(string path)
        {
            FilesDbContext filesDbContext = new FilesDbContext();

            var mainList = filesDbContext.Folders.Select(x => x.Path).ToList();

            if(!mainList.Contains(Path.GetDirectoryName(path)))
            {
                var folder = new Folder
                {
                    FolderId = Guid.NewGuid(),
                    Name = Path.GetDirectoryName(path),
                    Path = path,
                };

                filesDbContext.Folders.Add(folder);
                filesDbContext.SaveChanges();
            }
            
            var directoryPaths = Directory.EnumerateDirectories(path);
            foreach (var directoryPath in directoryPaths)
            {
                Console.WriteLine(directoryPath);
                OpenAllFiles(directoryPath);
                OpenAllDirectories(directoryPath);
            }
        }

        public static void OpenAllFiles(string path)
        {
            FilesDbContext filesDbContext = new FilesDbContext();

            var filePaths = Directory.EnumerateFiles(path);
            foreach (var filePath in filePaths)
            {
                var mainList = filesDbContext.Files.Select(x => x.Name).ToList();
                if (!mainList.Contains(Path.GetDirectoryName(path)))
                {
                    Guid tempId = Guid.NewGuid();
                    try
                    {
                        tempId = filesDbContext.Folders.Where(f => f.Name == Path.GetDirectoryName(filePath))
                        .FirstOrDefault().FolderId;
                    }
                    catch (NullReferenceException)
                    {
                        
                        tempId = Guid.NewGuid();
                    }

                    File file = new File
                    {
                        Id = Guid.NewGuid(),
                        Name = Path.GetFileName(filePath),
                        Size = new FileInfo(filePath).Length,
                        FullPath = filePath,
                        FolderId = tempId,
                    };
                    filesDbContext.Files.Add(file);
                }
            }
            filesDbContext.SaveChanges();
        }

    }
}
