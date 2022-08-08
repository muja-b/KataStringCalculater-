using System;
namespace Kata
{
    class StringCalc
    {
        static void Main(string[] args)
        {
            KataStringCalcolator FactoredCalc = new KataStringCalcolator();
            int ans = FactoredCalc.add("1/n,2,3,4");
            Console.WriteLine(ans);
        }

    }
    class KataStringCalcolator : ICalculater
    {
        public int add(string Numbers)
        {

            try
            {
                return tryAddWithEndLine(Numbers);
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
        private int tryAddWithEndLine(string Numbers)
        {
            int ans;
            string endLine = "/n";
            Numbers = Numbers.Replace("/n", "");
            ans = Numbers.Where(x => x != ',').Aggregate((sum, i) => sum += i);
            ans -= Numbers.Where(x => x != ',').Count() * '0';
            return ans;
        }

    }

}
