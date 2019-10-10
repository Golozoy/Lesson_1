using System;
using System.Collections.Generic;
using System.IO;

namespace Хитрый_код
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirName = "C:\\logs";
            string ch;
            do
            {
                Console.WriteLine("Введите имя прибора, для которого хотите получить информацию: ");
            
                ch = Console.ReadLine();
                Lupach(dirName, ch);

                Console.WriteLine("q  повтор");
            }
            while (Console.ReadLine() == "q");
            
        }

        public static void Lupach(string file_name, string pribor)
        {
            List<string> Po = new List<string>();
            Console.WriteLine();
            string[] files = Directory.GetFiles(file_name);
            int a = 0;
            bool flag = true;

            foreach (string s in files)
            {
                if (!flag)
                    break;
                foreach (string leg in File.ReadAllLines(s))
                {
                    Po.AddRange(leg.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries));
                }
                for (; a < Po.Count; a++)
                {
                    if (pribor == Po[a])
                    {
                        if (pribor.IndexOf("garbage") != -1)
                        {
                            Console.WriteLine("Слово \"garbage\" найдено в строке");
                            flag = false;
                            break;
                        }
                        Console.WriteLine(s.Substring(13, 16) + $"-{Po[a - 1]} , Результат замеров: {Po[a + 1]}");
                    }
                     if (Po.Count == a)
                        Console.WriteLine("Устройство не найдено ");
                    
                    
                }

            }

            for (int i = 1; i < Po.Count; i += 3)

                Console.WriteLine($"name_devaise: {Po[i]} ");
        }
    }
}