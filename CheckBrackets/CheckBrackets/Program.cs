using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CheckBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----{ CHECK BRACKETS }----");
            Console.Write("Press any key to continue: ");
            Console.ReadKey();

            bool bracketsAreValid = CheckBrackets();

            if (bracketsAreValid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("Valid");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine("Not valid");
                Console.ResetColor();
            }
        }

        public static bool CheckBrackets()
        {
            bool check = true;

            try
            {
                Console.Write("You file path (Default path is .....\\netcoreapp2.1\\): ");

                Console.ForegroundColor = ConsoleColor.Blue;
                string fileName = Console.ReadLine();

                Stack openingBrackets = new Stack();
                Queue closingBrackets = new Queue();

                using (StreamReader reader = new StreamReader(fileName))
                {
                    string str = reader.ReadToEnd();
                    char[] code = str.ToCharArray();

                    foreach (char ch in code)
                    {
                        if (ch == '(' || ch == '[' || ch == '{')
                        {
                            openingBrackets.Push(ch);
                        }
                        else if (ch == ')' || ch == ']' || ch == '}')
                        {
                            if (ch == ')' && (char)openingBrackets.Peek() == '(')
                            {
                                openingBrackets.Pop();
                            }
                            else if (ch == ']' && (char)openingBrackets.Peek() == '[')
                            {
                                openingBrackets.Pop();
                            }
                            else if (ch == '}' && (char)openingBrackets.Peek() == '{')
                            {
                                openingBrackets.Pop();
                            }
                        }
                    }

                    if (openingBrackets.Count != closingBrackets.Count)
                    {
                        check = false;
                    }

                    reader.Close();
                }

                return check;
            }
            catch (Exception exp)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Catched exception: ");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(exp);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;

                return false;
            }
        }
    }
}
