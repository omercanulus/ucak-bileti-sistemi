namespace UcakBiletiSistemi.Models
{

    // Sistemimde iki tür kullanıcı vardır: Admin ve Müşteriler. Bu sınıftaki özellikler her iki tür kullanıcı için de geçerlidir.
    //Daha sonrasında bu sınıftan türetecegimiz alt sınıflarda kalıtım özelliğini kullanarak admin ve müşteriye özel özellikler eklenecek.
    //Kalıtım özelliği ise buradaki özellikleri tekrar etmememek için bana yardımcı olacak. Kod tekrarına girmemiş olacağım.
    public abstract class Kullanici
    {
        // Bu sınıftan doğrudan nesneler oluşturulamaz. Abstract (Soyut) sınıftır.
        // Tüm kullanıcıların ortak özellikleri
        public int ID { get; set; }
        public required string KullaniciAdi { get; set; }
        public required string Sifre { get; set; }

        // Bu metot, her alt sınıf tarafından zorunlu olarak uygulanmalıdır.
        // Bu, Polymorphism (Çok Biçimlilik) kuralının ilk adımıdır.
        public abstract string RolNedir();
    }
}

