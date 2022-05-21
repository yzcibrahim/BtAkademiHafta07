using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        public static int findDifference(string str)
        {
            int ACount = 0;
            int BCount = 0;
            for (int i= 0;i<str.Length;i++)
            {
                if (str[i].ToString() == "A")
                    ACount++;
                else if(str[i].ToString() == "B")
                    BCount++;
            }
            return Math.Abs(ACount - BCount);

            return 0;

        }
        static void Main(string[] args)
        {
            
            //Console.WriteLine("Hello World!");
            //123=>1 * 100 + 20 * 10 + 3 * 1;

            Console.WriteLine("sayı giriniz");
            int a = Convert.ToInt32(Console.ReadLine());

            //int birler = a % 10 ;

            //int onlar = a % 100 - 1*birler;
            //onlar = onlar / 10;

            //int yuzler = a % 1000 - 1*birler - 10*onlar;
            //yuzler = yuzler / 100;

            //int binler = a % 10000 - 1 * birler - 10 * onlar - 100 * yuzler;
            //binler = binler / 1000;

            // BasamakLarinaAyir(a);
            basamaklarinaAyirByStr(a);

            ///
            ///
        }

        private static List<int> basamaklarinaAyirByStr(int a)
        {
            List<int> result = new List<int>();
            string aStr = a.ToString();
            var aArray = aStr.ToCharArray();

            for(int i=aArray.Length-1;i>=0;i--)
            {
                var eleman = aArray[i].ToString();

                result.Add(Convert.ToInt32(eleman));
            }

            return result;
            
        }

        private static List<int> BasamakLarinaAyir(int a)
        {
            List<int> basamakDegerler = new List<int>();
            int cikarilacak = 0;
            for (int i = 0; ; i++)
            {
                int basamak = (int)Math.Pow(10, i);

                if (a < basamak)
                    break;

                var kalan = a % (basamak * 10);
                kalan = kalan - cikarilacak;

                kalan = kalan / basamak;



                cikarilacak += basamak * kalan;
                basamakDegerler.Add(kalan);
            }
            return basamakDegerler;

        }
    }
}
