namespace Task2;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Укажите путь до директории");
        var p = Console.ReadLine();
        var d = new DirectoryInfo(p);
        Console.WriteLine($"Объём директории {DirSize(d)}");
    }
    
    public static long DirSize(DirectoryInfo d) 
    {    
        long size = 0;    
        // Размер файла.
        var fis = d.GetFiles();
        foreach (var fi in fis) 
        {      
            size += fi.Length;    
        }
        // Размер папки.
        var dis = d.GetDirectories();
        foreach (DirectoryInfo di in dis) 
        {
            size += DirSize(di);   
        }
        return size;  
    }
}