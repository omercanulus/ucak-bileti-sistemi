using UcakBiletiSistemi.Models;

namespace UcakBiletiSistemi.Yonetim
{
    public static class KullaniciRepository
    {
        // Uygulamanın çalışması için hafızada tutulan kullanıcı listesi (statik)
        private static List<Kullanici> Kullanicilar = new List<Kullanici>
        {
            // ADMIN Kullanıcısı
            new Admin
            {
                ID = 1, // Kullanici sınıfından miras
                KullaniciAdi = "admin",
                Sifre = "12345",
            },
            
            // MÜŞTERİ Kullanıcısı
            new Musteri
            {
                ID = 2, // Kullanici sınıfından miras
                KullaniciAdi = "musteri",
                Sifre = "123",
                TcNo = "11122233344",
        YolcuAdSoyad = "Omer Can Ulus",
            }
        };

        // Kullanıcı adı ve şifre ile giriş yapan kullanıcıyı bulur
        public static Kullanici? GirisYap(string kullaniciAdi, string sifre)
        {
            return Kullanicilar.FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi && k.Sifre == sifre);
        }
    }
}