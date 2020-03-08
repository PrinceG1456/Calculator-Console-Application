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
            methods.Add("multiply", Multiply);
        }

        public static string Calculate(string[] args)
        {
            if (args.Length == 0)
            {
                return "No inputs provided."; ;
            }

            if (args.Length == 1)
            {
                return "0";
            }

            if (args.Length == 2)
            {
                var val = SanitizeInput(args[1]);
                List<int> negativeNumerList = HasNegativeNumers(val);

                if (negativeNumerList.Count > 0)
                {
                    
                    return "Negative numbers [" + String.Join(",", negativeNumerList) + "] not allowed."; ;
                }
                return methods[args[0].ToLower()](val).ToString();
            }

            return "Not defined";
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
                return "Problem with the provided delimiter";
            }
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
                sum += val > 1000 ? 0 : val;
            }
            return sum;
        }

        private static int Multiply(IEnumerable<int> enumerable)
        {
            int mul = 1;
            foreach (int val in enumerable)
            {
                mul *= val > 1000 ? 1 : val;
            }
            return mul;
        }
    }
}
