using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using namespace Kutyák;







class Program
{
    static void Main(string[] args)
    {
        List<KutyaNevek> kutyanevek = new List<KutyaNevek>();
        List<KutyaFajtak> kutyafajtak = new List<KutyaFajtak>();
        List<Kutya> kutyak = new List<Kutya>();

        using (StreamReader reader = new StreamReader("KutyaNevek.csv"))
        {
            reader.ReadLine();
            string sor;
            while ((sor = reader.ReadLine()) != null)
            {
                kutyanevek.Add(new KutyaNev(sor));
            }
        }

        using (StreamReader reader = new StreamReader("KutyaFajtak.csv"))
        {
            reader.ReadLine();
            string sor;
            while ((sor = reader.ReadLine()) != null)
            {
                kutyafajtak.Add(new KutyaFajta(sor));
            }
        }

        using (StreamReader reader = new StreamReader("Kutyak.csv"))
        {
            reader.ReadLine();
            string sor;
            while ((sor = reader.ReadLine()) != null)
            {
                kutyak.Add(new Kutya(sor));
            }
        }

        Console.WriteLine("3. feladat: Kutyanevek száma: " + kutyanevek.Count);

        double atlagKor = kutyak.Average(k => k.kor);
        Console.WriteLine("6. feladat: Kutyák átlagéletkora: " + Math.Round(atlagKor, 2));

        Kutya legidosebbKutya = kutyak.OrderByDescending(k => k.kor).First();
        string legidosebbNev = kutyanevek.First(n => n.id == legidosebbKutya.nev_id).nev;
        string legidosebbFajta = kutyafajtak.First(f => f.id == legidosebbKutya.fajta_id).nev;
        Console.WriteLine("7. feladat: A legidősebb kutya neve és fajtája: " + legidosebbNev + ", " + legidosebbFajta);

        Console.WriteLine("8. feladat: Január 10.-én a vizsgált kutya fajták:");
        List<string> fajtak = kutyak.Where(k => k.vizsgalat == "2018.01.10").Select(k => fajta(k.fajta_id)).ToList();
        foreach (var fajta in fajtak.Distinct())
        {
            Console.WriteLine($"\t{fajta}: {fajtak.Count(f => f == fajta)} kutya");
        }

        Console.Write("9. feladat: Legjobban leterhelt nap: ");
        string legterheltebbNap = kutyak.GroupBy(k => k.vizsgalat).OrderByDescending(g => g.Count()).First().Key;
        int kutyaSzam = kutyak.Count(k => k.vizsgalat == legterheltebbNap);
        Console.WriteLine($"{legterheltebbNap}: {kutyaSzam} kutya");

        Console.WriteLine("10. feladat: nevstatisztika.txt");
        List<string> nevek = kutyak.Select(k => nev(k.nev_id)).ToList();
        var gyakorisag = nevek.GroupBy(n => n).Where(g => g.Count() > 1).Select(g => new { Nev = g.Key, Gyakorisag = g.Count() }).OrderByDescending(g => g.Gyakorisag);
        using (StreamWriter writer = new StreamWriter("nevstatisztika.txt"))
        {
            foreach (var item in gyakorisag)
            {
                writer.WriteLine($"{item.Nev};{item.Gyakorisag}");
            }
        }
    }

    static string fajta(int fajta_id)
    {
        foreach (var egy in kutyafajtak)
        {
            if (egy.id == fajta_id)
                return egy.nev;
        }
        return null;
    }

    static string nev(int nev_id)
    {
        foreach (var egy in kutyanevek)
        {
            if (egy.id == nev_id)
                return egy.nev;
        }
        return null;
    }
}
