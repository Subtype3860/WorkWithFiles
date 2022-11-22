namespace Task3;

internal class Program
{
    public static void Main()
    {
        
    }
    /// <summary>
    /// Расчёт объёма директории
    /// </summary>
    /// <param name="directoryInfo">Класс DirectoryInfo</param>
    /// <returns></returns>
    public static long DirSize(DirectoryInfo directoryInfo) 
    {    
        long size = 0;
        try
        {
            // Размер файла.
            var fis = directoryInfo.GetFiles();
            foreach (var fi in fis) 
            {      
                size += fi.Length;    
            }
            // Размер папки.
            var dis = directoryInfo.GetDirectories();
            foreach (DirectoryInfo di in dis) 
            {
                size += DirSize(di);   
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        return size;  
    }

    /// <summary>
    /// Очистка директории
    /// </summary>
    /// <param name="path">Путь к директории</param>
    private static void GetCatalogs(string path)
    {
        if (Directory.Exists(path))
        {
            //Список подпапок
            var dirs = Directory.GetDirectories(path);
            foreach (var dir in dirs)
                try
                {
                    Directory.Delete(dir, true);
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Для директории {dir} установлен статус {e.Message}");
                    throw;
                }
            //Список файлов
            var files = Directory.GetFiles(path);
            foreach (var file in files)
                try
                {
                    File.Delete(file);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Для файла {file} установлен статус {e.Message}");
                    throw;
                }
        }
        else
        {
            Console.WriteLine("Директория не существует");
        }

        Console.ReadKey();
    }
}