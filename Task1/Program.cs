using System;
using System.IO;

namespace Task1;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Укажите путь до каталога:");
        var path = Console.ReadLine();
        GetCatalogs(path!);
    }
    static void GetCatalogs(string path)
    {
        if (Directory.Exists(path))
        {
            try
            {
                var dirTime = Directory.GetLastWriteTime(path);
                var timeSpan = TimeSpan.FromMinutes(30);
                var dateTime = DateTime.Now - timeSpan;
                if (dateTime < dirTime) return;
                var dirs = Directory.GetDirectories(path);
                foreach (var dir in dirs)
                {
                    Directory.Delete(dir);
                }

                var files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        else
        {
            Console.WriteLine("Директория не существует");
        }
    }
}