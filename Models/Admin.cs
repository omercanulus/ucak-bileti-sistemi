namespace UcakBiletiSistemi.Models
{
    // Admin de Kullanici'dan miras alır.
    public class Admin : Kullanici
    {
        // Admin de ana metodu uyguluyor.
        public override string RolNedir()
        {
            return "Admin";
        }

        // Admin'in yapabileceği özel bir metot.
        // Bu metodu Müşteri nesneleri kullanamaz.
        public void UcusEkle(Ucus yeniUcus)
        {
            // Şu anlık sadece mesaj final zamanı tam kapsamlı şekilde olacak.
            Console.WriteLine($"Admin tarafından {yeniUcus.KalkisSehri}-{yeniUcus.VarisSehri} uçuşu sisteme eklendi.");
        }
    }
}