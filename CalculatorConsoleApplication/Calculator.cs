using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorConsoleApplication
{
    public static class Calculator
    {
        private static Dictionary<string, Func<IEnumerable<int>, int>> methods = new Dictionary<string, Func<IEnumerable<int>, int>>();
        private static List<Char> delimiters = new List<Char> { ',', '\n' };

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
                List<int> negativeNumerList = HasNegativeNumers(val);

                if (negativeNumerList.Count > 0)
                {
                    Console.WriteLine("Negative numbers [" + String.Join(",", negativeNumerList) + "] not allowed.");
                    return;
                }
                Console.WriteLine(methods[args[0].ToLower()](val));
                return;
            }

           
        }

        private static List<int> HasNegativeNumers(IEnumerable<int> val)
        {
            List<int> list = new List<int>();
            foreach (var v in val)
            {
                if (v < 0)
                {
                    list.Add(v);
                }
            }
            return list;
        }

        private static IEnumerable<int> SanitizeInput(string input)
        {
            string str = input.Replace(@"\n", "\n"); // To replace \\n with \n
            str = checkForDelimiter(str);
            return StringToIntList(str);
        }

        private static string checkForDelimiter(string input)
        {
            String[] strArray = input.Split("\\", StringSplitOptions.RemoveEmptyEntries);
            if (strArray.Length == 1)
                return strArray[0];
            try
            {
                delimiters.Add(Convert.ToChar(strArray[0]));
                return strArray[1];
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem with the provided delimiter");
            }

            return null;
        }

        private static IEnumerable<int> StringToIntList(string str)
        {
            if (String.IsNullOrEmpty(str))
                yield break;

            foreach (var s in str.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                int num;
                if (int.TryParse(s, out num))
                    yield return num;
            }
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
    }
}
