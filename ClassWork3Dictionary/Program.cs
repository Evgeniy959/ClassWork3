using System;
using System.Collections.Generic;
using System.IO;

namespace ClassWork3Dictionary
{
    class Program
    {
        static void Main()
        {
            var dict = new Dictionary<string, string>();
            //dict.Add("байт", "единица хранения и обработки цифровой информации; совокупность битов, обрабатываемая компьютером одновременно");
            //dict.Add("бит", "единица измерения количества информации");

            var exit = false;
            do
            {
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Напечатать весь словарь");
                Console.WriteLine("2. Сохранить в файл");
                Console.WriteLine("3. Загрузить из файла");
                Console.WriteLine("0. Выход");
                var select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        PrintDict(dict);
                        break;
                    case "2":
                        ImportToFile(dict);
                        break;
                    case "3":
                        dict = ExportFromFile();
                        break;
                    case "0":
                        Console.WriteLine("До свидания");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            } while (!exit);


        }

        static void PrintDict(Dictionary<string, string> dict)
        {
            foreach (var element in dict)
            {
                Console.WriteLine($"{element.Key} - {element.Value}");
            }
        }

        static void ImportToFile(Dictionary<string, string> dict)
        {
            var file = new StreamWriter("it.dict", true);
            foreach (var element in dict)
            {
                file.WriteLine($"{element.Key}|{element.Value}");
            }
            // file.Flush();
            file.Close();
        }

        static Dictionary<string, string> ExportFromFile()
        {
            var file = new StreamReader("it.dict");
            var dict = new Dictionary<string, string>();

            var str = string.Empty;
            while ((str = file.ReadLine()) != null)
            {
                var temp = SplitStr(str, '|');
                dict.Add(temp.key, temp.value);
            }
            file.Close();

            return dict;
        }

        static (string key, string value) SplitStr(string str, char delimiter)
        {
            var temp = str.Split(delimiter);
            var key = temp[0];
            var value = temp[1];

            return (key, value);
        }
    }
}
        
    

