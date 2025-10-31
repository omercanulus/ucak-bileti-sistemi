using System.Collections.Generic;
using UcakBiletiSistemi.Models; // Ucus sınıflarımızı kullanmak için

namespace UcakBiletiSistemi.Yonetim
{
    // 'static' kelimesi: Bu sınıf, tüm proje için tek bir merkezde durur.
    // Onu kullanmak için yeni bir nesne (kopya) oluşturmaya gerek kalmaz.
    public static class UcusYoneticisi
    {
        // Veri tabanı yerine geçecek basit bir liste. Finalde veri tabanı eklenmiş olacak.

        private static List<Ucus> UcusListesi = new List<Ucus>();

        static UcusYoneticisi()
        {
            UcusListesi.Add(new Ucus
            {
                UcusID = 101,
                KalkisSehri = "İstanbul",
                VarisSehri = "Ankara",
                KalkisTarihi = DateTime.Now.AddDays(7),
                AnaFiyat = 500,
                Kapasite = 100,
                BosKoltukSayisi = 100
            });

            UcusListesi.Add(new Ucus
            {
                UcusID = 102,
                KalkisSehri = "Ankara",
                VarisSehri = "İzmir",
                KalkisTarihi = DateTime.Now.AddDays(10),
                AnaFiyat = 650,
                Kapasite = 150,
                BosKoltukSayisi = 150
            });
        }


        // Admin'in yeni bir uçuş eklemesi için metot
        public static void UcusEkle(Ucus yeniUcus)
        {
            UcusListesi.Add(yeniUcus);
        }

        // Müşterinin arama yapması için metot
        public static List<Ucus> UcuslariAra(string kalkis, string varis)
        {
            // Liste içinde, KalkisSehri ve VarisSehri bilgisi eşleşen uçuşları bulur.
            return UcusListesi.Where(a => a.KalkisSehri.Equals(kalkis, StringComparison.OrdinalIgnoreCase) &&
                                       a.VarisSehri.Equals(varis, StringComparison.OrdinalIgnoreCase))
                           .ToList();
        }

        // Tüm uçuşları listeleme metodu (Admin için)
        public static List<Ucus> TumUcuslariGetir()
        {
            return UcusListesi;
        }


        // Rezervasyon yapıldığında koltuk azaltma
        public static void KoltukAzalt(int ucusId)
        {
            var ucus = UcusListesi.FirstOrDefault(u => u.UcusID == ucusId);
            if (ucus != null && ucus.BosKoltukSayisi > 0)
            {
                ucus.BosKoltukSayisi--;
            }
        }

        // Rezervasyon iptali durumunda koltuk artırma
        public static void KoltukArtir(int ucusId)
        {
            var ucus = UcusListesi.FirstOrDefault(u => u.UcusID == ucusId);
            if (ucus != null && ucus.BosKoltukSayisi < ucus.Kapasite)
            {
                ucus.BosKoltukSayisi++;
            }
        }
        public static Ucus? UcusBul(int id)
        {
            // FirstOrDefault: UcusID'si eşleşeni bul, yoksa boş döndür.
            return UcusListesi.FirstOrDefault(u => u.UcusID == id);
        }
    }
}