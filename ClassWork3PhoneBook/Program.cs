/*Задание.
Доработать программу "Телефонный справочник" следующим образом:
добавить сохранение данных в файл перед закрытием
добавить импорт данных из файла при старте программы
реализовать ручной выбор сохранения данных в файл с вводом имени файла.*/

using System;
using System.Collections.Generic;
using System.IO;

namespace ClassWork3PhoneBook
{
    class Program
    {
        /*static void Main()
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
}*/
        static void Main()
        {
            var exit = false;
            var phoneBook = new Dictionary<string, string>();
            phoneBook = ExportFromFile();

            do
            {
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Добавить");
                Console.WriteLine("2. Редактировать");
                Console.WriteLine("3. Удалить");
                Console.WriteLine("4. Найти");
                Console.WriteLine("5. Показать всё");
                Console.WriteLine("6.Загрузить из файла ");
                Console.WriteLine("7.Сохранить в новый файл");
                Console.WriteLine("0. Выход, cохранить в файл");
                var select = Console.ReadLine();
                switch (select)
                {
                    case "1": // 1. Добавить
                        AddRecord(phoneBook);
                        break;
                    case "2": // 2. Редактировать
                        Edit(phoneBook);
                        break;
                    case "3": // 3. Удалить
                        Delete(phoneBook);
                        break;
                    case "4": // 4. Найти
                        Find(phoneBook);
                        break;
                    case "5": // 5. Показать всё
                        PrintDictionary(phoneBook);
                        break;
                    case "6":
                        phoneBook = ExportFromFile();
                        break;
                    case "7":
                        //ImportToFilePath(phoneBook);
                        //ImportToFile(phoneBook);
                        AddFile();
                        break;
                    case "0": // 0. Выход
                        ImportToFile(phoneBook);
                        exit = true;
                        break;
                    default: // Неправильный ввод
                        Console.WriteLine("Повторите ввод");
                        Console.WriteLine();
                        break;
                }
            } while (!exit);
            Console.WriteLine("До свидания...");
        }
        static Dictionary<string, string> ExportFromFile()
        {
            /*var path = "phoneBook.txt";
            StreamReader reader = new StreamReader(path);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                var temp = SplitStr(str, '|');
                phoneBook.Add(temp.key, temp.value);
            }
            reader.Close();*/ 
            var file = new StreamReader(Inputpath());
            var phoneBook = new Dictionary<string, string>();

            var str = string.Empty;
            while ((str = file.ReadLine()) != null)
            {
                var temp = SplitStr(str, '|');        
                phoneBook.Add(temp.key, temp.value);
            }
            file.Close();

            return phoneBook;
        }

        static (string key, string value) SplitStr(string str, char delimiter)
        {
            var temp = str.Split(delimiter);
            var key = temp[0];
            var value = temp[1];

            return (key, value);
        }

        static void Edit(Dictionary<string, string> dictionary)
        {
            var flag = false;

            Console.Write("Введите имя - ");
            var name = Console.ReadLine();

            foreach (var element in dictionary)
            {
                if (element.Value == name)
                {
                    dictionary.Remove(element.Key);
                    flag = true;
                }
            }
            if (flag)
            {
                Console.Write("Введите новый номер телефона - ");
                var phone = Console.ReadLine();
                dictionary.Add(phone, name);
            }
            if (!flag)
            {
                Console.WriteLine("Ничего не найдено");
            }
        }

        static void Delete(Dictionary<string, string> dictionary)
        {
            var flag = false;

            Console.Write("Введите имя - ");
            var name = Console.ReadLine();

            foreach (var element in dictionary)
            {
                if (element.Value == name)
                {
                    dictionary.Remove(element.Key);
                    //dictionary.Remove(element.Value);
                    flag = true;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Ничего не найдено");
            }
        }

        static void Find(Dictionary<string, string> dictionary)
        {
            var flag = false;
            Console.Write("Введите имя - ");
            var name = Console.ReadLine();

            foreach (var element in dictionary)
            {
                if (element.Value == name)
                {
                    Console.WriteLine($"{element.Value} - {element.Key}");
                    flag = true;
                }
            }

            if (!flag)
            {
                Console.WriteLine("Ничего не найдено");
            }
        }
        static void AddRecord(Dictionary<string, string> dictionary)
        {
            var flagAdd = false;
            Console.Write("Введите имя - ");
            var name = Console.ReadLine();
            Console.Write("Введите номер телефона - ");
            var phone = Console.ReadLine();
            foreach (var element in dictionary)
            {
                if (element.Value == name && element.Key == phone)
                {
                    Console.WriteLine("Имя c данным номером уже существует");
                    flagAdd = true;
                }
            }
            if (!flagAdd)
            {
                dictionary.Add(phone, name);
            }
        }
        static void AddFile()
        {
            var phoneBook = new Dictionary<string, string>();
            Console.WriteLine("Введите данные которые хотите сохранить: ");
            /*Console.Write("Имя - ");
            var name = Console.ReadLine();
            Console.Write("Номер телефона - ");
            var phone = Console.ReadLine();
            phoneBook.Add(phone, name);*/
            //dictionary.Add(phone, name);
            AddRecord(phoneBook);
            ImportToFilePath(phoneBook);
        }
        static string Inputpath()
        {
            Console.WriteLine("Введите имя файла - ");
            string path = Console.ReadLine();
            return path;
        }
        static void ImportToFile(Dictionary<string, string> dictionary)
        {
            //var path = "phoneBook.txt";
            //StreamWriter file = new StreamWriter(path, append: true);
            //var file = new StreamWriter("it.phoneBook", true);
            var file = new StreamWriter("it.phoneBook", true);
            foreach (var element in dictionary)
            {
                file.WriteLine($"{element.Key}|{element.Value}");
            }
            // file.Flush();
            file.Close();
        }
        static void ImportToFilePath(Dictionary<string, string> dictionary)
        {
            //var path = "phoneBook.txt";
            //StreamWriter file = new StreamWriter(path, append: true);
            //var file = new StreamWriter("it.phoneBook", true);
            var file = new StreamWriter(Inputpath(), true);
            foreach (var element in dictionary)
            {
                file.WriteLine($"{element.Key}|{element.Value}");
            }
            // file.Flush();
            file.Close();
        }

        static void PrintDictionary(Dictionary<string, string> dictionary)
        {
            foreach (var element in dictionary)
            {
                Console.WriteLine($"{element.Key}: {element.Value}");
            }
        }
    }
}



