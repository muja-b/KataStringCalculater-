using System;
namespace Kata
{
    class StringCalc
    {
        static void Main(string[] args)
        {
            KataStringCalcolator FactoredCalc = new KataStringCalcolator();
            int ans = FactoredCalc.add("3,44,1");
            Console.WriteLine(ans);
        }

    }
    class KataStringCalcolator : ICalculater
    {
        public int add(string Numbers)
        {

            try
            {
                return tryAdddelimiters(Numbers);
            }
            catch (System.Exception)
            {
                return 0;
            }

        }
        private int tryAdd(string Numbers)
        {
            int ans;
            ans = Numbers.Where(x => x != ',').Aggregate((sum, i) => sum += i);
            ans -= Numbers.Where(x => x != ',').Count() * '0';
            return ans;
        }
        private int tryAddbig(string Numbers)
        {
            List<string> Nums = Numbers.Split(',').ToList();
            int sum = 0;
            foreach (var item in Nums)
            {
                sum += Int32.Parse(item);
            }

            return sum;
        }
        private int tryAddWithEndLine(string Numbers)
        {
            Numbers = Numbers.Replace("/n", ",");
            List<string> Nums = Numbers.Split(',').ToList();
            int sum = 0;
            foreach (var item in Nums)
            {
                sum += Int32.Parse(item);
            }

            return sum;
        }
        private int tryAdddelimiters(string Numbers)
        {
            char endLine = ',';
            if (Numbers.StartsWith("//"))
            {
                endLine = Numbers[2];
                Numbers = Numbers.Remove(0,3);
                Numbers = Numbers.Replace("/n", endLine + "");
            }
            List<string> Nums = Numbers.Split(endLine).ToList();
            int sum = 0;
            foreach (var item in Nums)
            {
                sum += Int32.Parse(item);
            }

            return sum;
        }


    }

}
