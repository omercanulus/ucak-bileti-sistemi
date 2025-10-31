namespace UcakBiletiSistemi.Models
{
    // Kullanıcı sınıfının tüm özellikleri ve metotları aldığını gösterir yani Kalıtım yapar.
    public class Musteri : Kullanici
    {
        // Müşteriye özel ek özellikler
        public required string TcNo { get; set; }
        public required string YolcuAdSoyad { get; set; }

        // Ana sınıftan gelen metodu uyguluyoruz (Polymorphism/Çok Biçimlilik kuralı).
        // Artık bir Musteri nesnesi RolNedir diye sorulduğunda "Müşteri" diye cevap verecektir.
        public override string RolNedir()
        {
            return "Müşteri";
        }
    }
}