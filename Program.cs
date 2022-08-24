using System;
namespace Kata
{
    class StringCalc
    {
        static void Main(string[] args)
        {
            KataStringCalcolator FactoredCalc = new KataStringCalcolator();
            int ans = FactoredCalc.add("1,2,3,4");
            Console.WriteLine(ans);
        }

    }
    class KataStringCalcolator : ICalculater
    {
        public int add(string Numbers)
        {

            try
            {
                return tryAddbig(Numbers);
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
                System.Console.WriteLine(item);
                sum += Int32.Parse(item);
            }
            return sum;
        }
        private int tryAddWithEndLine(string Numbers)
        {
            int ans;
            string endLine = "/n";
            Numbers = Numbers.Replace("/n", "");
            ans = Numbers.Where(x => x != ',').Aggregate((sum, i) => sum += i);
            ans -= Numbers.Where(x => x != ',').Count() * '0';
            return ans;
        }
        private int tryAdddelimiters(string Numbers)
        {
            int ans;
            char endLine = Numbers[2];
            Numbers = Numbers.Replace("/n", "");
            Numbers = Numbers.Replace("//", "");
            ans = Numbers.Where(x => x != endLine).Aggregate((sum, i) => sum += i);
            ans -= Numbers.Where(x => x != endLine).Count() * '0';
            return ans;
        }


    }

}
