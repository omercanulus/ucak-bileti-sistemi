using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UcakBiletiSistemi.Models;
using UcakBiletiSistemi.Yonetim; // KullaniciRepository'i çağırır

namespace UcakBiletiSistemi.Pages
{
    public class GirisModel : PageModel
    {
        // HTML formundan gelecek verileri yakalamak için
        [BindProperty]
        public required string KullaniciAdi { get; set; } 

        [BindProperty]
        public required string Sifre { get; set; }

        public string? HataMesaji { get; set; }

        // ZORUNLU METOT: Sayfa yüklendiğinde çalışır
        public void OnGet() { } 

        // Türkçe İsimlendirmeli Metot: Form gönderildiğinde çalışır
        // OnPost'un sonuna Türkçe bir kelime ekleyerek ne iş yaptığını belirtiyoruz.
        public IActionResult OnPostGirisYap() // <- İSİM BURADA UZATILDI
        {
            var kullanici = KullaniciRepository.GirisYap(KullaniciAdi, Sifre);

            if (kullanici == null)
            {
                HataMesaji = "Kullanıcı adı veya şifre yanlış.";
                return Page();
            }
            
            // Giriş BAŞARILI
            
            if (kullanici.RolNedir() == "Admin")
            {
                return RedirectToPage("./AdminUcusEkle"); 
            }
            else if (kullanici.RolNedir() == "Müşteri")
            {
                return RedirectToPage("./Index"); 
            }

            HataMesaji = "Tanımlanamayan kullanıcı rolü.";
            return Page();
        }
    }
}