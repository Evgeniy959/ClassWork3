using System;
using System.IO;

namespace ClassWork3
{
    class Program
    {
        static void Main()
        {
            /*var path = "test.txt";
            StreamWriter file = new StreamWriter(path, append: true);
            file.WriteLine("Привет мир!");
            file.Close();

            StreamReader read_file = new StreamReader(path);
            var temp = read_file.ReadToEnd();
            read_file.Close();

            Console.WriteLine(temp);

            StreamReader reader = new StreamReader(path);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(line);
            }
            reader.Close();*/

            /*var path = "privet.txt";
            var pathCopy = "privetCopy.txt";
            Console.WriteLine("Укажите путь к файлу");
            StreamWriter file = new StreamWriter(path, append: true);
            file.WriteLine("Привет мир и счастья всем!");
            StreamWriter fileCopy = new StreamWriter(pathCopy, append: true);
            //fileCopy.WriteLine("Привет мир!");
            
            //file = fileCopy;
            file.Close();
            /*StreamReader reader = new StreamReader(path);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(line);
            }*/

            Console.Write("Введите имя файла");
            var temp_name = Console.ReadLine();
            var temp_str = temp_name.Split('.');

            var file_name = temp_str[0];
            var file_ext = temp_str[1];

            var file_copy = $"{file_name}_copy.{file_ext}";
            var file_head = $"{file_name}_head.{file_ext}";

        }
    }
}
