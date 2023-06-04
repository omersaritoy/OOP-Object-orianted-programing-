using System;
using System.Collections.Generic;

// Örnek kullanım


Banka banka = new Banka();

Musteri musteri1 = new Musteri() { Ad = "Ahmet", Soyad = "Yılmaz" };
Musteri musteri2 = new Musteri() { Ad = "Ayşe", Soyad = "Demir" };

banka.MusteriEkle(musteri1);
banka.MusteriEkle(musteri2);

banka.HesapAc("1234567890", "Ahmet Yılmaz");
banka.HesapAc("9876543210", "Ayşe Demir");

banka.ParaTransferi("1234567890", "9876543210", 500);

Console.ReadLine();


// Hesap sınıfı
class Hesap
{
    public string HesapNumarasi { get; set; }
    public string HesapSahibi { get; set; }
    public decimal Bakiye { get; set; }

    public void ParaYatir(decimal miktar)
    {
        Bakiye += miktar;
        Console.WriteLine(miktar + " TL hesaba yatırıldı. Güncel bakiye: " + Bakiye + " TL");
    }

    public void ParaCek(decimal miktar)
    {
        if (miktar <= Bakiye)
        {
            Bakiye -= miktar;
            Console.WriteLine(miktar + " TL hesaptan çekildi. Güncel bakiye: " + Bakiye + " TL");
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye. İşlem gerçekleştirilemedi.");
        }
    }
}

// Müşteri sınıfı
class Musteri
{
    public string Ad { get; set; }
    public string Soyad { get; set; }

    public void HesapAc(string hesapNumarasi, string hesapSahibi)
    {
        Hesap yeniHesap = new Hesap()
        {
            HesapNumarasi = hesapNumarasi,
            HesapSahibi = hesapSahibi,
            Bakiye = 0
        };

        Console.WriteLine("Yeni hesap açıldı. Hesap numarası: " + hesapNumarasi);
    }

    public void HesapKapat(string hesapNumarasi)
    {
        Console.WriteLine("Hesap kapatıldı. Hesap numarası: " + hesapNumarasi);
    }
}

// Banka sınıfı
class Banka
{
    private List<Musteri> musteriler = new List<Musteri>();
    private Dictionary<string, Hesap> hesaplar = new Dictionary<string, Hesap>();

    public void MusteriEkle(Musteri musteri)
    {
        musteriler.Add(musteri);
    }

    public void HesapAc(string hesapNumarasi, string hesapSahibi)
    {
        if (!hesaplar.ContainsKey(hesapNumarasi))
        {
            Musteri musteri = new Musteri() { Ad = hesapSahibi.Split(' ')[0], Soyad = hesapSahibi.Split(' ')[1] };
            musteri.HesapAc(hesapNumarasi, hesapSahibi);

            Hesap yeniHesap = new Hesap() { HesapNumarasi = hesapNumarasi, HesapSahibi = hesapSahibi, Bakiye = 0 };
            hesaplar.Add(hesapNumarasi, yeniHesap);

            Console.WriteLine("Hesap başarıyla açıldı.");
        }
        else
        {
            Console.WriteLine("Bu hesap numarasına sahip bir hesap zaten bulunmaktadır.");
        }
    }

    public void HesapKapat(string hesapNumarasi)
    {
        if (hesaplar.ContainsKey(hesapNumarasi))
        {
            Musteri musteri = musteriler.Find(m => m.Ad == hesaplar[hesapNumarasi].HesapSahibi.Split(' ')[0] && m.Soyad == hesaplar[hesapNumarasi].HesapSahibi.Split(' ')[1]);
            musteri.HesapKapat(hesapNumarasi);

            hesaplar.Remove(hesapNumarasi);

            Console.WriteLine("Hesap başarıyla kapatıldı.");
        }
        else
        {
            Console.WriteLine("Bu hesap numarasına sahip bir hesap bulunamadı.");
        }
    }

    public void ParaTransferi(string kaynakHesapNumarasi, string hedefHesapNumarasi, decimal miktar)
    {
        if (hesaplar.ContainsKey(kaynakHesapNumarasi) && hesaplar.ContainsKey(hedefHesapNumarasi))
        {
            if (hesaplar[kaynakHesapNumarasi].Bakiye >= miktar)
            {
                hesaplar[kaynakHesapNumarasi].ParaCek(miktar);
                hesaplar[hedefHesapNumarasi].ParaYatir(miktar);

                Console.WriteLine(miktar + " TL " + kaynakHesapNumarasi + " hesabından " + hedefHesapNumarasi + " hesabına transfer edildi.");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye. İşlem gerçekleştirilemedi.");
            }
        }
        else
        {
            Console.WriteLine("Geçersiz hesap numarası(ları). İşlem gerçekleştirilemedi.");
        }
    }
}


    

