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

            Soru();
            return;
            string a1 = "asd";

            Console.WriteLine("hello" + a1);
            Console.WriteLine($"hello {a1}");
            
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

        private static void Soru()
        {
            #region soru
            /*Have the function StringChallenge(str) take the str parameter and swap the case of each character. Then, if a letter is between two numbers (without separation), switch the places of the two numbers. For example: if str is "6Hello4 -8World, 7 yes3" the output should be 4hELLO6 -8wORLD, 7 YES3.
                Examples
                Input: "Hello -5LOL6"
                Output: hELLO -6lol5
                Input: "2S 6 du5d4e"
                Output: 2s 6 DU4D5E
                Browse Resources
                Search for any help or documentation you might need for this problem. For example: array indexing, Ruby hash tables, etc.

            */
            #endregion
            while (true)
            {
                string deger = Console.ReadLine();
                List<string> res = new List<string>();
                int firstNumindex = -1;
                int secondNumIndex = -1;
                
                for (int i = 0; i < deger.Length; i++)
                {
                    if (deger[i].ToString() == " ")
                    {
                        firstNumindex = -1;
                    }
                    if (int.TryParse(deger[i].ToString(), out int a))
                    {
                        res.Add(deger[i].ToString());
                        if(firstNumindex==-1)
                        {
                            firstNumindex = i;
                        }
                        else
                        {
                            secondNumIndex = i;
                        }

                        if (secondNumIndex != -1 && firstNumindex != -1)
                        {
                            string temp = res[firstNumindex];
                            res[firstNumindex] = res[secondNumIndex];
                            res[secondNumIndex] = temp;
                        }
                        
                    }
                    else
                    {
                        if (deger[i].ToString().ToUpper() == deger[i].ToString())
                        {
                            res.Add(deger[i].ToString().ToLower());
                        }
                        else
                        {
                            res.Add(deger[i].ToString().ToUpper());
                        }
                    }
                }

                string finalRes = "";// string.Join('', res);
              foreach(var item in res)
                {
                    finalRes += item;
                }


            }

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
