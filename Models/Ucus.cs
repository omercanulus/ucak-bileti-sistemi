namespace UcakBiletiSistemi.Models
{

    public class Ucus
    {
        //Uçuşların Özeliklleri.
        public int UcusID { get; set; }
        public required string KalkisSehri { get; set; }
        public required string VarisSehri { get; set; }
        public DateTime KalkisTarihi { get; set; }
        public int Kapasite { get; set; }
        public int BosKoltukSayisi { get; set; }
        public double AnaFiyat { get; set; }

        //Uçuşların fiyatını hesaplayacak metot. Finalde detaylı olacak.
        public double FiyatHesapla()
        {
            return AnaFiyat;
        }
    }
}
