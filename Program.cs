using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;

namespace LambdaExpressions
{
    internal class Program
    {
        delegate int MyHandler(int i);
        public static void Main(string[] args)
        {
            var lesson = new Lesson("Программирование C#");
            lesson.Started += (sender, date) =>
            {
                Console.WriteLine(sender);
                Console.WriteLine(date);
            };
            
            lesson.Start();

            var list = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }
            var res = list.Aggregate((x, y) => x + y);
            Console.WriteLine(res);

            Console.WriteLine();
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                MyHandler handler = delegate(int i)
                {
                    var r = i * i;
                    Console.WriteLine(r);
                    return i * i;
                };

                handler += Methed;
                handler(result);

                MyHandler lambdaHandler = (i) =>                                                              //реализация лямбда выражения
                {
                    var r = i * i;
                    Console.WriteLine(r);
                    return i * i;
                };
                
                lambdaHandler(99);
            }

            Console.ReadLine();
        }

        public static int Methed(int i)
        {
            var r = i * i * i;
            Console.WriteLine(r);
            return i * i;
        }
    }
}