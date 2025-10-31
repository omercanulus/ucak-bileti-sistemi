
using Microsoft.AspNetCore.Mvc.RazorPages;
using UcakBiletiSistemi.Models;
using UcakBiletiSistemi.Yonetim;
using Microsoft.AspNetCore.Mvc; // Formdan veri almak için

namespace UcakBiletiSistemi.Pages;

// ... namespace ve sınıf tanımının içine

public class IndexModel : PageModel
{
    // Formdan Kalkış ve Varış şehirlerini yakalamak için
    [BindProperty(SupportsGet = true)] // Hem post hem de ilk yüklemede (get) çalışır
    public string KalkisSehri { get; set; } = "";

    [BindProperty(SupportsGet = true)]
    public string VarisSehri { get; set; } = "";

    // Sonuçları tutacak liste
    public List<Ucus> AramaSonuclari { get; set; } = new List<Ucus>();

    // -------------------------------------------------------------

    // Sayfa ilk yüklendiğinde çalışır (http://localhost:5002/)
    public void OnGet()
    {
        // Kullanıcı ilk kez geldiğinde veya bir arama yapıldığında, 
        // sonuçları listeye çekmek için OnPost metodu da kullanılabilir.
        // Şimdilik sadece tüm uçuşları gösterelim.
        AramaSonuclari = UcusYoneticisi.TumUcuslariGetir();
    }

    // Form gönderildiğinde (Arama Butonuna basıldığında) çalışir
    public IActionResult OnPostAra()
    {
        // Eğer Kalkış ve Varış bilgisi varsa, arama yap:
        if (!string.IsNullOrEmpty(KalkisSehri) && !string.IsNullOrEmpty(VarisSehri))
        {
            AramaSonuclari = UcusYoneticisi.UcuslariAra(KalkisSehri, VarisSehri);
        }
        else
        {
            // Bilgi yoksa tüm uçuşları getir (veya hata mesajı verilebilir)
            AramaSonuclari = UcusYoneticisi.TumUcuslariGetir();
        }

        // Sonuçlarla birlikte sayfayı tekrar göster
        return Page();
    }
}

