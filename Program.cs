namespace Kata
{
    class StringCalc
    {
        static void Main(string[] args)
        {
            KataStringCalcolator FactoredCalc = new KataStringCalcolator();
            int ans = FactoredCalc.add("-3,4010,5");
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
            var ParsedNums = ParseListToInt(Nums);
            int sum = GetSum(ParsedNums);
            return sum;
        }
        private int tryAddWithNewLine(string Numbers)
        {
            var myNumbers = Numbers.Replace("/n", ",");
            List<string> Nums = myNumbers.Split(',').ToList();
            var ParsedNums = ParseListToInt(Nums);
            int sum = GetSum(ParsedNums);
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
            var ParsedNums = ParseListToInt(Nums);
            int sum = GetSum(ParsedNums);
            return sum;
        }

        private List<int> ParseListToInt(List<string> nums)
        {
            var Parsed = new List<int>();
            foreach (var item in nums)
            {
                Parsed.Add(Int32.Parse(item));
            }
            return Parsed;
        }

        private int tryAdddelimitersWithNegitave(string Numbers)
        {
            char diameter = ',';
            if (Numbers.StartsWith("//"))
            {
                diameter = Getdiameter(Numbers);
            }
            var myNumbers=RemoveNewLine(Numbers, diameter);
            List<string> Nums = myNumbers.Split(diameter).ToList();
            var myNums=ParseListToInt(Nums);
            testNegitaves(myNums);
            int sum = GetSum(myNums);
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
            var myNums=ParseListToInt(Nums);
            testNegitaves(myNums);
            var filterdNums=FilterNums(myNums);
            int sum = GetSum(filterdNums);
            return sum;
        }

        private List<int> FilterNums(List<int> nums)
        {   
            var myNumbers=new List<int>();
            foreach (var item in nums)
            {   
                myNumbers.Add(item%1000);   
            }
            return myNumbers;
        }

        private int GetSum(List<int> nums)
        {
            int sum = 0;
            foreach (var item in nums)
            {
                sum += item;
            }
            return sum;
        }

        private void testNegitaves(List<int> Nums)
        {
            var negitave = Nums.Where(x => x<0).ToList();
            if (negitave.Count != 0 && Nums != null)
            {
                string msg = "";
                foreach (var item in negitave)
                {
                    msg +=item + " ";
                }
                throw new NegitaveNotAllowedException(msg);
            }
        }

        private string RemoveNewLine(string numbers, char diameter)
        {
            var myNumbers = numbers.Replace("/n", diameter + "");
            return myNumbers;
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
