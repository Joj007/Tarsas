using System;

namespace huhuuuu // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. feladat
            List<Ösvény> osvenyek = new();
            File.ReadAllLines("osvenyek.txt").ToList().ForEach(n=>osvenyek.Add(new Ösvény(n.ToList())));
            List<Dobas> dobasok = new();
            File.ReadAllLines("dobasok.txt").ToList().ForEach(n => n.Split(' ').ToList().ForEach(m=>dobasok.Add(new Dobas(Convert.ToInt32(m)))));

            //2. feladat
            Console.WriteLine($"2. feladat\nA dobások száma: {dobasok.Count}\nAz ösvények száma: {osvenyek.Count}");

            //3. feladat
            Ösvény legnagyobbOsveny = osvenyek.MaxBy(n => n.Osveny.Count);
            Console.WriteLine($"3. feladat\nAz egyik leghosszabb a(z) {legnagyobbOsveny.Index}. ösvény, hossza: {legnagyobbOsveny.Osveny.Count}");

            //4. feladat
            Console.WriteLine("4. feladat");
            /*
            int kivalasztottSorszam;
            do
            {
                Console.WriteLine("Adja meg egy ösvény sorszámát! ");
                kivalasztottSorszam = Console.Read();
            } while (kivalasztottSorszam < 1 || kivalasztottSorszam > Ösvény.OsvenyekSzama);

            Ösvény kivalasztottOsveny = osvenyek[kivalasztottSorszam + 1];
            int jatekosokSzama;
            do
            {
                Console.WriteLine("Adja meg a játékosok számát! ");
                jatekosokSzama = Console.Read();
            } while (jatekosokSzama < 2 || jatekosokSzama > 5);
            */
            Console.WriteLine("Adja meg egy ösvény sorszámát! ");
            int kivalasztottSorszam = Convert.ToInt32(Console.ReadLine());
            Ösvény kivalasztottOsveny = osvenyek[kivalasztottSorszam-1];
            Console.WriteLine("Adja meg a játékosok számát! ");
            int jatekosokSzama = Convert.ToInt32(Console.ReadLine());


            //5. feladat
            Console.WriteLine($"5. feladat\n");
            Console.WriteLine($"M: {kivalasztottOsveny.CountM}");
            Console.WriteLine($"V: {kivalasztottOsveny.CountV}");
            Console.WriteLine($"E: {kivalasztottOsveny.CountE}");

            //7. feladat
            List<int> Porog()
            {
                int korSeged = 0;
                int[] szum = new int[jatekosokSzama];
                List<int> eredmenyek;
                for (int kor = 0; kor < dobasok.Count / jatekosokSzama; kor++)
                {
                    for (int i = 0; i < jatekosokSzama; i++)
                    {
                        szum[i] += dobasok[kor * jatekosokSzama + i].getDobas;
                    }

                    foreach (int szam in szum)
                    {
                        if (szam >= kivalasztottOsveny.Osveny.Count)
                        {
                            eredmenyek = szum.ToList();
                            eredmenyek.Add(kor+1);
                            return eredmenyek;
                        }
                    }
                    korSeged = kor;
                }
                eredmenyek = szum.ToList();
                eredmenyek.Add(korSeged + 1);
                return eredmenyek;
            }

            int[] szumok;
            List<int> eredmenyek = Porog();
            szumok = eredmenyek.ToArray()[..^1];
            int korokSzama = eredmenyek.ToArray()[^1];
            int maxIndex = 0;
            int maxErtek = szumok[0];
            for (int i = 1; i < szumok.Count(); i++)
            {
                if (szumok[i] > maxErtek)
                {
                    maxErtek = szumok[i];
                    maxIndex = i;
                }
            }

            Console.WriteLine($"7. feladat\nA játék a(z) {korokSzama}.körben fejeződött be.A legtávolabb jutó(k) sorszáma: {maxIndex+1}");



            //8. feladat

            List<int> NagyonPorog()
            {
                int korSeged = 0;
                int[] szum = new int[jatekosokSzama];
                List<int> eredmenyek;
                for (int kor = 0; kor < dobasok.Count / jatekosokSzama; kor++)
                {
                    for (int i = 0; i < jatekosokSzama; i++)
                    {


                        szum[i] += dobasok[kor * jatekosokSzama + i].getDobas;
                        if (szum[i] < kivalasztottOsveny.Osveny.Count)
                        {
                            if (kivalasztottOsveny.Osveny[szum[i]] == 'E')
                            {
                                szum[i] += dobasok[kor * jatekosokSzama + i].getDobas;
                            }
                            else if (kivalasztottOsveny.Osveny[szum[i]] == 'V')
                            {
                                szum[i] -= dobasok[kor * jatekosokSzama + i].getDobas;
                            }
                        }

                    }

                    foreach (int szam in szum)
                    {
                        if (szam >= kivalasztottOsveny.Osveny.Count)
                        {
                            eredmenyek = szum.ToList();
                            eredmenyek.Add(kor + 1);
                            return eredmenyek;
                        }
                    }
                    korSeged = kor;
                }
                eredmenyek = szum.ToList();
                eredmenyek.Add(korSeged + 1);
                return eredmenyek;
            }

            int[] nagyonszumok;
            List<int> nagyoneredmenyek = NagyonPorog();
            nagyonszumok = nagyoneredmenyek.ToArray()[..^1];
            int nagyonkorokSzama = nagyoneredmenyek.ToArray()[^1];
            int nagyonmaxIndex = 0;
            int nagyonmaxErtek = nagyonszumok[0];
            for (int i = 1; i < nagyonszumok.Count(); i++)
            {
                if (nagyonszumok[i] > nagyonmaxErtek)
                {
                    nagyonmaxErtek = nagyonszumok[i];
                    nagyonmaxIndex = i;
                }
            }

            nagyonszumok.ToList().ForEach(n=>Console.WriteLine(n));

        }
    }
}