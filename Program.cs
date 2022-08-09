namespace Kata
{
    class StringCalc
    {
        static void Main(string[] args)
        {
            KataStringCalcolator FactoredCalc = new KataStringCalcolator();
            int ans = FactoredCalc.add("3,4010,5");
            Console.WriteLine(ans);
        }

    }
    class KataStringCalcolator : ICalculater
    {
        public int add(string Numbers)
        {

            try
            {
                return tryAdddelimitersWithNegitaveIgnoreingBigNumbers(Numbers);
            }

            catch (FormatException)
            {
                return 0;
            }

        }
        private int tryAddSimple(string Numbers)
        {
            int ans;
            ans = Numbers.Where(x => x != ',').Aggregate((sum, i) => sum += i);
            ans -= Numbers.Where(x => x != ',').Count() * '0';
            return ans;
        }
        private int tryAddbig(string Numbers)
        {
            List<string> Nums = Numbers.Split(',').ToList();
            int sum = GetSum(Nums);
            return sum;
        }
        private int tryAddWithEndLine(string Numbers)
        {
            Numbers = Numbers.Replace("/n", ",");
            List<string> Nums = Numbers.Split(',').ToList();
            int sum = GetSum(Nums);
            return sum;
        }
        private int tryAdddelimiters(string Numbers)
        {
            char diameter = ',';
            if (Numbers.StartsWith("//"))
            {
                diameter = Getdiameter(Numbers);
            }
            List<string> Nums = Numbers.Split(diameter).ToList();
            int sum = GetSum(Nums);
            return sum;
        }
        private int tryAdddelimitersWithNegitave(string Numbers)
        {
            char diameter = ',';
            if (Numbers.StartsWith("//"))
            {
                diameter = Getdiameter(Numbers);
            }
            RemoveNewLine(Numbers, diameter);
            List<string> Nums = Numbers.Split(diameter).ToList();
            testNegitaves(Nums);
            int sum = GetSum(Nums);
            return sum;
        }
        private int tryAdddelimitersWithNegitaveIgnoreingBigNumbers(string Numbers)
        {
            char diameter = ',';
            if (Numbers.StartsWith("//"))
            {
                diameter = Getdiameter(Numbers);
            }
            RemoveNewLine(Numbers, diameter);
            List<string> Nums = Numbers.Split(diameter).ToList();
            testNegitaves(Nums);
            FilterNums(Nums);
            int sum = GetSum(Nums);
            return sum;
        }

        private void FilterNums(List<string> nums)
        {
            for (int i = 0; i < nums.Count(); i++)
            {
                if (nums.ElementAt(i).Count() > 3)
                {
                    var LargeNum = nums.ElementAt(i).Substring(nums.ElementAt(i).Count()-3,3);
                    nums.RemoveAt(i);
                    nums.Add(LargeNum);
                }
            }
        }

        private int GetSum(List<string> nums)
        {
            int sum = 0;
            foreach (var item in nums)
            {
                sum += Int32.Parse(item);
            }

            return sum;
        }

        private void testNegitaves(List<string> Nums)
        {
            var negitave = Nums.Where(x => x.StartsWith("-")).ToList();
            if (negitave.Count != 0 && Nums != null)
            {
                string msg = "";
                foreach (var item in negitave)
                {
                    msg += item + " ";
                }
                throw new NegitaveNotAllowedException(msg);
            }
        }

        private void RemoveNewLine(string numbers, char diameter)
        {
            numbers = numbers.Replace("/n", diameter + "");
        }

        public char Getdiameter(string numbers)
        {
            char diameter = numbers[2];
            numbers = numbers.Remove(0, 3);
            return diameter;
        }

        public class NegitaveNotAllowedException : Exception
        {
            public NegitaveNotAllowedException(string message)
                : base("negatives not allowed:" + message)
            {
            }
        }
    }


}
