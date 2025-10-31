using System.Collections.Generic;
using UcakBiletiSistemi.Models;
using UcakBiletiSistemi.Yonetim;

namespace UcakBiletiSistemi.Yonetim
{
    public static class RezervasyonYoneticisi
    {
        // Tüm rezervasyonları tutacak liste
        private static List<Rezervasyon> RezervasyonListesi = new List<Rezervasyon>();
        private static int SonRezervasyonID = 0;

        // Rezervasyon oluşturma metodu
        public static Rezervasyon RezervasyonOlustur(int ucusId, string yolcuAdSoyad, string koltukNo)
        {
            // Yeni Rezervasyon Nesnesi Oluşturma
            SonRezervasyonID++;
            var yeniRezervasyon = new Rezervasyon
            {
                RezervasyonID = SonRezervasyonID,
                UcusID = ucusId,
                YolcuAdSoyad = yolcuAdSoyad,
                KoltukNo = koltukNo,
                // Durum required üye olarak başlatılıyor
                Durum = "Aktif",
                OdemeTutari = 0
            };

            // Rezervasyonu listeye ekleme
            RezervasyonListesi.Add(yeniRezervasyon);

            // Uçuşun koltuk sayısını güncelleme
            UcusYoneticisi.KoltukAzalt(ucusId);

            return yeniRezervasyon; // Oluşan rezervasyonu geri döndür
        }

        // Rezervasyon iptal etme metodu (RezervasyonID ile)
        public static bool RezervasyonIptalEt(int rezervasyonId)
        {
            var rezervasyon = RezervasyonListesi.FirstOrDefault(r => r.RezervasyonID == rezervasyonId);

            if (rezervasyon != null && rezervasyon.Durum != "İptal Edildi")
            {
                rezervasyon.Durum = "İptal Edildi";
                // Uçuşun koltuk sayısını geri artırma
                UcusYoneticisi.KoltukArtir(rezervasyon.UcusID);
                return true;
            }
            return false;
        }

        // Admin veya Müşteri için listeleme metodu
        public static List<Rezervasyon> TumRezervasyonlariGetir()
        {
            return RezervasyonListesi;
        }
        // Tek bir rezervasyonu ID'si ile bulmak için metot
        public static Rezervasyon? RezervasyonBul(int id)
        {
            return RezervasyonListesi.FirstOrDefault(r => r.RezervasyonID == id);
        }

    }
}