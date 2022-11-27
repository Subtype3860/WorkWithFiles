using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Task4;

class Program
{
    public static void Main()
    {
        Reader(null);
    }

    /// <summary>
    /// Чтение бинарного файла
    /// </summary>
    /// <param name="path">Путь до бинарного файла</param>
    private static async void Reader(string? path)
    {
        var student = new List<Student>();
        var p = path ?? "Students.dat";

        using (var s = new BinaryReader(File.Open(p, FileMode.Open), Encoding.UTF8))
        {
            while (s.PeekChar() > -1)
            {
                var ss = s.Read();
                string dd = s.ReadString();
                Console.WriteLine($"{ss}  {dd}");

            }
        }

        Console.ReadKey();

    }
}