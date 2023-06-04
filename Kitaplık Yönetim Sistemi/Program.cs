
// Örnek kullanım

// Kitapları oluştur
Kitap kitap1 = new Kitap()
{
    Isim = "Harry Potter ve Felsefe Taşı",
    Yazar = "J.K. Rowling",
    Yayinevi = "YKY",
    YayinTarihi = new DateTime(1997, 6, 26),
    ISBN = "9789750800901"
};

Kitap kitap2 = new Kitap()
{
    Isim = "1984",
    Yazar = "George Orwell",
    Yayinevi = "Can Yayınları",
    YayinTarihi = new DateTime(1949, 6, 8),
    ISBN = "9789750730510"
};

// Kütüphane oluştur
Kutuphane kutuphane = new Kutuphane();
kutuphane.KitapEkle(kitap1);
kutuphane.KitapEkle(kitap2);

class Kitap
{
    public string Isim { get; set; }
    public string Yazar { get; set; }
    public string Yayinevi { get; set; }
    public DateTime YayinTarihi { get; set; }
    public string ISBN { get; set; }
}

// Kütüphane sınıfı
class Kutuphane
{
    private List<Kitap> kitaplar = new List<Kitap>();

    public void KitapEkle(Kitap kitap)
    {
        kitaplar.Add(kitap);
    }

    public void KitapSil(Kitap kitap)
    {
        kitaplar.Remove(kitap);
    }

    public void KitaplarListele()
    {
        foreach (Kitap kitap in kitaplar)
        {
            Console.WriteLine("Kitap İsmi: " + kitap.Isim);
            Console.WriteLine("Yazar: " + kitap.Yazar);
            Console.WriteLine("Yayınevi: " + kitap.Yayinevi);
            Console.WriteLine("Yayın Tarihi: " + kitap.YayinTarihi.ToShortDateString());
            Console.WriteLine("ISBN: " + kitap.ISBN);
            Console.WriteLine("----------------------");
        }
    }
}

// Kullanıcı sınıfı
class Kullanici
{
    public string Ad { get; set; }
    public string Soyad { get; set; }

    public void KitapOduncAl(Kitap kitap)
    {
        Console.WriteLine(Ad + " " + Soyad + ", " + kitap.Isim + " kitabını ödünç aldı.");
    }

    public void KitapIadeEt(Kitap kitap)
    {
        Console.WriteLine(Ad + " " + Soyad + ", " + kitap.Isim + " kitabını iade etti.");
    }
}
