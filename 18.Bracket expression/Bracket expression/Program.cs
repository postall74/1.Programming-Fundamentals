using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bracket_expression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text; 
            char character1 = '(';
            char charapter2 = ')';
            bool isInvalid = false;
            int depth = 0;
            Stack<char> stack = new Stack<char>();
            Console.Write("Input text: ");
            text = Console.ReadLine();

            foreach (char symbol in text)
            {
                if (symbol == character1)
                {
                    stack.Push(symbol);
                    depth = 0;
                }

                if (symbol == charapter2)
                {
                    if (stack.Count == 0)
                    {
                        isInvalid = true;
                        break;
                    }
                    stack.Pop();
                    depth += 1;
                }
            }

            if (isInvalid != true && stack.Count == 0)
            {
                Console.WriteLine(text + " - строка корректна. Максимальна глубина " + depth);
            }
            else
            {
                Console.WriteLine(text + " - строка не корректна.");
            }
        }
    }
}