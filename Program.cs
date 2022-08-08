using System;
namespace Kata
{
    class StringCalc
    {
        static void Main(string[] args)
        {
            KataStringCalcolator FactoredCalc = new KataStringCalcolator();
            int ans = FactoredCalc.add("1,2,3");
            Console.WriteLine(ans);
        }

    }
    class KataStringCalcolator : ICalculater
    {
        public int add(string Numbers)
        {

            try
            {
                return tryAdd(Numbers);
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

    }
}
