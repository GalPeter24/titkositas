using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace titkositas
{
        internal class Program
        {
            static int eltolas; //eltolás mértéke
            static void Main(string[] args)
            {
                List<string> sorok = new List<string>();

                ConsoleKeyInfo mitValasztott = Menu();
                String sor, fajlNev;
                switch (mitValasztott.Key)
                {
                    case ConsoleKey.F1:
                        Console.Write("Kérem a titkosítási kulcsot!:");
                        eltolas = int.Parse(Console.ReadLine());
                        do
                        {
                            Console.Write("Kérem a titkosítandó szöveget! :");
                            sor = Console.ReadLine();
                            sorok.Add(sor);
                        }
                        while (sor != "");

                        break;
                    case ConsoleKey.F2:
                        Console.Write("Kérem a kódolt fájl nevét! :");
                        fajlNev = Console.ReadLine();
                        Console.WriteLine(Visszafejt(FajlbolOlvas(fajlNev)));
                        break;
                    default:
                        Console.WriteLine("The end!");
                        return;
                }
                foreach (string s in sorok) { FajlbaIr("kodolt.txt", Titkositott(s, eltolas)); }
            }


            private static List<string> FajlbolOlvas(string fajlNev)
            {
                StreamReader sr = new StreamReader(fajlNev);

                List<string> olvasott = new List<string>();
                while (!sr.EndOfStream)
                {
                    eltolas = int.Parse(sr.ReadLine());  //Ezt is vizsgálni kellene!
                    String sor = sr.ReadLine();



                }
                sr.Close();
                return olvasott;
            }


            /// <summary>
            /// A megadott állományba írja az átalakított szöveget
            /// </summary>
            /// <param name="fileName">Elérési útvonal és a fájl neve</param>
            /// <param name="textLine">A fájlba írandó szöveg</param>
            private static void FajlbaIr(string fileName, string textLine)  //módosítani a paramétert pld string listára
            {
                StreamWriter sw = new StreamWriter(fileName);
                sw.WriteLine(eltolas);
                sw.WriteLine(textLine); //Át kell írni
                sw.Close();
            }

            private static ConsoleKeyInfo Menu()
            {
                Console.Clear();
                Console.WriteLine($"[F1] Titkosít");
                Console.WriteLine($"[F2] Visszafejt");
                Console.WriteLine($"[ESC] Vissza");
                ConsoleKeyInfo karakter;
                do
                {
                    Console.WriteLine("\nVálasszon !");
                    karakter = Console.ReadKey();

                } while (karakter.Key != ConsoleKey.F1 && karakter.Key != ConsoleKey.F2 && karakter.Key != ConsoleKey.Escape);
                return karakter;
            }

            private static string Titkositott(string szoveg, int eltolas)
            {
                StringBuilder kodolt = new StringBuilder();

                foreach (char jel in szoveg)
                {
                    int jelUjKodja = (byte)jel + eltolas;
                    kodolt.Append((char)jelUjKodja);
                }
                return kodolt.ToString();
            }

            private static string Visszafejt(string szoveg)
            {
                StringBuilder visszafejtett = new StringBuilder();

                foreach (char jel in szoveg)
                {
                    int jelUjKodja = (byte)jel - eltolas;
                    visszafejtett.Append((char)jelUjKodja);
                }
                return visszafejtett.ToString();
            }
        }
    }

    