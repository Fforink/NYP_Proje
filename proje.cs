using System;
using System.Collections.Generic;

enum cihazTuru
{
    Lamba,
    Klima,
    GuvenlikSistemi
}

class Cihaz
{
    public string Kimlik { get; private set; }
    public string Ad { get; private set; }
    public cihazTuru Tur { get; private set; }
    public bool AcikMi { get; private set; } = false;

    public Cihaz(string kimlik, string ad, cihazTuru tur)
    {
        if (string.IsNullOrEmpty(kimlik))
            throw new ArgumentException("Kimlik boş bırakılamaz!");

        if (string.IsNullOrEmpty(ad))
            throw new ArgumentException("Ad bos birakilamaz!");
        Kimlik = kimlik;
        Ad = ad;
        Tur = tur;
    }

    public void Ac()
    {
        AcikMi = true;
    }
    public void Kapat()
    {
        AcikMi = false;
    }

    public void BilgileriGöster()
    {
        Console.WriteLine($"Kimlik: {Kimlik}");
        Console.WriteLine($"Ad: {Ad}");
        Console.WriteLine($"Tur: {Tur}");
        Console.Write($"Durum:");
        Console.WriteLine(AcikMi ? "Acik" : "Kapali");
    }
}



class Program
{
    public static void Main()
    {
        try
        {
            List<Cihaz> cihazlar = new List<Cihaz>();
            int choice = -1;
            while (choice != 0)
            {
                MenuInfo();

                Console.WriteLine("Seciminizi giriniz: ");
                string userInput = Console.ReadLine();
                bool gecerliSayı = int.TryParse(userInput, out choice);
                if (!gecerliSayı)
                {
                    Console.WriteLine("Gecerli bir sayı değil.");
                    choice = -1;
                    continue;
                }
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        //ekleme

                        string kimlik;
                        bool aynıVar = false;
                        string ad;
                        string stur;
                        cihazTuru tur;

                        Console.WriteLine("Cihaz için gerekli bilgileri doldurunuz:");
                        Console.WriteLine();
                        Console.WriteLine("Kimlik: ");
                        kimlik = Console.ReadLine();
                        foreach(Cihaz c in cihazlar)
                        {
                            if(c.Kimlik == kimlik)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Aynı kimlikte iki cihaz bulunamaz!!");
                                Console.WriteLine();

                                aynıVar = true;
                                break;
                            }
                        }
                        if (aynıVar)
                            break;
                        Console.WriteLine("Ad: ");
                        ad = Console.ReadLine();

                        Console.WriteLine("Tur: ");
                        stur = Console.ReadLine();
                        if (stur.ToLower() == "lamba")
                        {
                            tur = cihazTuru.Lamba;
                        }
                        else if (stur.ToLower() == "guvenlik sistemi")
                        {
                            tur = cihazTuru.GuvenlikSistemi;
                        }
                        else if (stur.ToLower() == "klima")
                        {
                            tur = cihazTuru.Klima;
                        }
                        else
                        {
                            Console.WriteLine("Gecerli tur degil.");
                            break;
                        }
                        Cihaz yeniCihaz = new Cihaz(kimlik,ad,tur);
                        cihazlar.Add(yeniCihaz);
                        break;
                    case 2:
                        string k;
                        bool bulundu = false;
                        Console.WriteLine("Lütfen durumunu degistermek istediginiz cihazın kimligini giriniz: ");
                        k = Console.ReadLine();
                        Console.WriteLine();
                        foreach (Cihaz c in cihazlar)
                        {
                            if(c.Kimlik == k)
                            {
                                if (c.AcikMi)
                                {
                                    c.Kapat();
                                    Console.WriteLine("Cihaz kapatıldı.");
                                }
                                else
                                {
                                    c.Ac();
                                    Console.WriteLine("Cihaz acildi");
                                     
                                }
                                bulundu = true;
                                Console.WriteLine();
                                break;
                            }
                        }
                        if (!bulundu)
                            Console.WriteLine("Aranan kimlikte cihaz bulunamadı!");
                        Console.WriteLine();
                        break;

                    case 3:
                        int sıra = 0;
                        Console.WriteLine();
                        foreach(Cihaz c in cihazlar)
                        {
                            Console.WriteLine();
                            sıra++;
                            Console.WriteLine("Cihaz " + sıra + ":");
                            c.BilgileriGöster();
                            Console.WriteLine("**********");
                        }
                        if(sıra == 0)
                        {
                            Console.WriteLine("Herhangi bir cihaz ekli degil!!");
                            Console.WriteLine();
                        }
                        break;

                    case 0:
                        Console.WriteLine("**********");
                        Console.WriteLine("Byee");
                        break;

                    default:
                        Console.WriteLine("Gecerli bir sayı giriniz.");
                        choice = -1;
                        break;


                }

            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public static void MenuInfo()
    {
        Console.WriteLine("-----MENU-----");
        Console.WriteLine();
        Console.WriteLine("1-) Yeni cihaz ekle");
        Console.WriteLine("2-) Cihaz ac/kapat");
        Console.WriteLine("3-) Cihazlari listele");
        Console.WriteLine();
        Console.WriteLine("0-) Bitir");

    }


}