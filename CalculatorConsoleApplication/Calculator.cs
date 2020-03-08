﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorConsoleApplication
{
    public static class Calculator
    {
        private static Dictionary<string, Func<IEnumerable<int>, int>> methods = new Dictionary<string, Func<IEnumerable<int>, int>>();

        static Calculator()
        {
            methods.Add("sum", Sum);
            methods.Add("add", Sum);
        }

        public static void Calculate(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No inputs provided.");
                return;
            }

            if (args.Length == 1)
            {
                Console.WriteLine("0");
                return;
            }

            if (args.Length == 2)
            {
                var val = SanitizeInput(args[1]);
                Console.WriteLine(methods[args[0].ToLower()](val));
                return;
            }

           
        }

        private static IEnumerable<int> SanitizeInput(string input)
        {
            string str = input.Replace(@"\n", "\n"); // To replace \\n with \n
            return StringToIntList(str);
        }

        private static int Sum(IEnumerable<int> enumerable)
        {
            int sum = 0;
            foreach (int val in enumerable)
            {
                sum += val;
            }
            return sum;
        }

        private static IEnumerable<int> StringToIntList(string str)
        {
            if (String.IsNullOrEmpty(str))
                yield break;

            foreach (var s in str.Split(new Char[] { ',', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                int num;
                if (int.TryParse(s, out num))
                    yield return num;
            }
        }
    }
}
