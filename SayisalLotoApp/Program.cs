using System;

namespace SayisalLotoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sayısal loto tahmini yapan program
            //6 sayı seçilecek 1 ile 49 arasına bu şekilde 8 tane seri seçilecek

            Console.WriteLine("Sayısal Loto Tahmin Uygulaması");
            Console.WriteLine("===============================");
            Console.WriteLine();

            string secim = "";

            do
            {
                WriteMenu();

                secim = Console.ReadLine();

                Random rnd = new Random();

                switch (secim)
                {
                    case "0":
                        return;
                    case "1":
                        //Yeni tahmin üret

                        Generate(rnd);

                        Console.WriteLine();
                        Console.WriteLine("Tahminleriniz yukarıdadır, menüye dönmek için bir tuşa basınız.");
                        Console.ReadKey();
                        break;

                    case "2":
                        // Yeni tahmin üret kısıtlı

                        int tahminAdet = 0;

                        do
                        {
                            Console.WriteLine();
                            Console.Write("Lütfen tahmin adedi giriniz : ");
                            string tahminAdetStr = Console.ReadLine();
                            tahminAdet = int.Parse(tahminAdetStr);

                            if (tahminAdet > 8 || tahminAdet < 1)
                            {
                                WriteError(2);
                            }

                        } while (tahminAdet > 8 || tahminAdet < 1);
                        Generate1(rnd, tahminAdet);

                        Console.WriteLine();
                        Console.WriteLine("Tahminleriniz yukarıdadır, menüye dönmek için bir tuşa basınız.");
                        Console.ReadKey();

                        break;

                    case "3":

                        //kendin üret
                        //??
                        /*
                         Kullanıcıdan satır adedi alınır.
                        Her satır için 6 adet sayı alınır.(aynı sayıyı girememeli)
                        Tüm satır verileri alındıktan sonra tüm satılar yazdırılmalı ama sıralı(writebysort kullanılabilir)
                         */


                        break;
                    default:
                        WriteError(1);
                        break;
                }



            } while (secim != "0");
        }

        private static void Generate1(Random rnd, int tahminAdet)
        {
            for (int i = 0; i < tahminAdet; i++)
            {
                int[] tahminler = new int[6];

                for (int j = 0; j < tahminler.Length; j++)
                {
                    tahminler[j] = rnd.Next(1, 50);
                }

                WriteBySort(tahminler);
                Console.WriteLine();
            }
        }

        private static void WriteBySort(int[] tahminler)
        {
            Array.Sort(tahminler);



            for (int k = 0; k < tahminler.Length; k++)
            {
                Console.Write(tahminler[k] + "  ");

                if (k < tahminler.Length - 1)
                {
                    Console.Write(" - ");
                }
            }
        }

        private static void Generate(Random rnd)
        {
            for (int i = 0; i < 8; i++) //satırlar için dönüyoruz.
            {
                //object initializers - Bir nesnenin başlangıç değerleri verilmişse bu durumu ifade etmek için kullanılır. Örneğin ; int [] tahminler = new int [] { 1,2,3,4,5}; 

                int[] tahminler = new int[6];
                //{
                //    rnd.Next(1,50),
                //    rnd.Next(1,50),
                //    rnd.Next(1,50),
                //    rnd.Next(1,50),
                //    rnd.Next(1,50),
                //    rnd.Next(1,50),

                //};

                for (int j = 0; j < tahminler.Length; j++)
                {
                    bool hasName;
                    int sayi;
                    do
                    {
                        sayi = rnd.Next(1, 50);
                        hasName = false;

                        for (int m = 0; m < tahminler.Length; m++)
                        {
                            if (sayi == tahminler[m])
                            {
                                hasName = true;
                            }
                        }


                    } while (hasName);

                    tahminler[j] = sayi;

                }
                //int[] tahminler = new int[6];

                //tahminler[0] = rnd.Next(1, 50);
                //tahminler[1] = rnd.Next(1, 50);
                //tahminler[2] = rnd.Next(1, 50);
                //tahminler[3] = rnd.Next(1, 50);
                //tahminler[4] = rnd.Next(1, 50);
                //tahminler[5] = rnd.Next(1, 50);

                Array.Sort(tahminler);

                for (int k = 0; k < tahminler.Length; k++)
                {
                    Console.Write(tahminler[k] + "  ");

                }
                Console.WriteLine();

                //Console.Write(rnd.Next(1,50) + " - ");
                //Console.Write(rnd.Next(1,50) + " - ");
                //Console.Write(rnd.Next(1,50) + " - ");
                //Console.Write(rnd.Next(1,50) + " - ");
                //Console.Write(rnd.Next(1,50) + " - ");
                //Console.WriteLine(rnd.Next(1,50));

            }
        }

        private static void WriteMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();

            Console.WriteLine("Menü");
            Console.WriteLine("[1] - Yeni Tahmin Üret");
            Console.WriteLine("[2] - Yeni Tahmin Üret(Limitli)");
            Console.WriteLine("[2] - Kendin Üret");
            Console.WriteLine("[0] - Çıkış");
            Console.WriteLine();
            Console.Write("Seçiminiz : ");

        }

        private static void WriteError(string errorMessage, string errorTitle = " Yanlış giriş yaptınız.", bool hasReadKey = true)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;


            Console.WriteLine(errorTitle);
            Console.WriteLine(errorMessage);

            if (hasReadKey)
            {
                Console.ReadKey();
            }


        }

        private static void WriteError(int komut)
        {
            if (komut == 1)
            {
                Console.WriteLine("Yanlış giriş yaptınız.");
                Console.WriteLine("Lütfen menüye dönmek için bir tuşa basınız.");
                Console.ReadKey();
            }
            else if (komut == 2)
            {
                Console.WriteLine("Yanlış giriş yaptınız.");
                Console.WriteLine("1 ve 8 arasında bir değer giriniz.");
            }

            Console.ReadKey();
            Console.ResetColor();
        }

    }
}
