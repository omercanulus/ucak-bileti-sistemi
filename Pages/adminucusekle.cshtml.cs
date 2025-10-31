using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UcakBiletiSistemi.Models;
using UcakBiletiSistemi.Yonetim; // UcusYoneticisi sınıfımızı kullanmak için

namespace UcakBiletiSistemi.Pages
{
    // Bu sınıf, AdminUcusEkle.cshtml sayfasının tüm arka plan mantığını yönetir.
    public class AdminUcusEkleModel : PageModel
    {
        // 1. [BindProperty] Nedir? HTML formundan gelen veriyi otomatik olarak bu değişkene eşler.
        // Bu, Admin'in formda girdiği tüm bilgileri alacak Ucus kalıbımızdır.
        [BindProperty]
        public required Ucus YeniUcus { get; set; }

        public string? Mesaj { get; set; } // Admin'e başarı veya hata mesajı göstermek için

        // 2. OnGet Metodu: Sayfa tarayıcıda İLK YÜKLENDİĞİNDE çalışır.
        public IActionResult OnGet()
        {
            // Sayfa yüklendiğinde mesajı temizleyelim
            Mesaj = "";
            // Gerçek güvenlik sistemi (Authentication/Authorization) kurmadığımız için,
            // basitleştirilmiş bir kontrol yapısı kullanacağız:

            // ÖNEMLİ NOT: Burada, kullanıcının giriş yapıp yapmadığı kontrol edilmelidir.
            // (Şu an bu kontrolü yapmıyoruz, bunu Final için saklayabiliriz.)

            // Şu an sadece mesajı temizlesin ve sayfayı göstersin
            return Page();
        }

        // 3. OnPost Metodu: HTML formunda butona basılıp veri SUNUCUYA gönderildiğinde çalışır.
        public IActionResult OnPost()
        {
            // YeniUcus nesnesi (formdan gelen verilerle dolu) kullanıma hazır!

            // Yeni uçuşa otomatik bir ID atayalım (şimdilik basit bir sayı)
            YeniUcus.UcusID = UcusYoneticisi.TumUcuslariGetir().Count + 103;

            // Kapasiteyi otomatik olarak Boş Koltuk Sayısına eşitleyelim
            YeniUcus.BosKoltukSayisi = YeniUcus.Kapasite;

            // 4. Uçuş Yönetici sınıfını çağırıp, yeni uçuşu listeye ekliyoruz!
            UcusYoneticisi.UcusEkle(YeniUcus);

            Mesaj = $"Başarılı! {YeniUcus.KalkisSehri}-{YeniUcus.VarisSehri} uçuşu sisteme eklendi.";

            // Kullanıcıyı aynı sayfada tutmak için kullanılan standart komuttur.
            return Page();
        }
    }
}