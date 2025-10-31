
namespace UcakBiletiSistemi.Models
{

    public class Rezervasyon
    {
        //Rezervasyonun ozellikleri.
        public  int RezervasyonID { get; set; }
        public int UcusID { get; set; }
        public required  string YolcuAdSoyad { get; set; }
        public double OdemeTutari { get; set; }
        public required string Durum { get; set; } = "Onaylandı";
        public required string KoltukNo { get; set; }

        public  string IptalEt()
        {
            this.Durum = "İptal Edildi";
            return "Rezervasyon iptal edildi.";
        }


    }
}