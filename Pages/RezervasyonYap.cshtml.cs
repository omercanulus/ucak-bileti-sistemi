using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UcakBiletiSistemi.Models;
using UcakBiletiSistemi.Yonetim;

namespace UcakBiletiSistemi.Pages
{
    public class RezervasyonYapModel : PageModel
    {
        // URL'den gelecek Uçuş ID'sini yakalamak için
        [BindProperty(SupportsGet = true)] 
        public int UcusId { get; set; }

        // Müşterinin formdan gireceği yolcu bilgileri
        [BindProperty]
        public required string YolcuAdSoyad { get; set; } 

        [BindProperty]
        public required string KoltukNo { get; set; }

        public Ucus SecilenUcus { get; set; } = new Ucus { KalkisSehri = "", VarisSehri = "" };
        public string Mesaj { get; set; } = "";

        // Sayfa açılırken (URL ile UcusId geldiğinde) çalışır
        public IActionResult OnGet()
        {
            // UcusYoneticisi'nden seçilen uçuşu bulma metodu (Bu metodu UcusYoneticisi.cs'e eklememiz GEREKİYOR!)
            SecilenUcus = UcusYoneticisi.UcusBul(UcusId);

            if (SecilenUcus == null)
            {
                return NotFound(); // Eğer uçuş yoksa 404 hatası ver
            }

            return Page();
        }

        // Form gönderildiğinde (Rezervasyon Butonuna basıldığında) çalışır
        public IActionResult OnPost()
        {
            // Basit bir Koltuk Numarası kontrolü
            if (string.IsNullOrEmpty(KoltukNo))
            {
                Mesaj = "Lütfen koltuk numarası seçin!";
                SecilenUcus = UcusYoneticisi.UcusBul(UcusId);
                return Page();
            }

            // RezervasyonYoneticisi'ni çağırarak rezervasyonu oluşturma
            Rezervasyon yeniRezervasyon = RezervasyonYoneticisi.RezervasyonOlustur(
                UcusId,
                YolcuAdSoyad,
                KoltukNo
            );

            // Uçuş bilgilerini güncelle ve mesajı oluştur
            SecilenUcus = UcusYoneticisi.UcusBul(UcusId);
            Mesaj = $"Rezervasyonunuz Başarılı! Rezervasyon ID: {yeniRezervasyon.RezervasyonID}. Uçuş: {SecilenUcus.KalkisSehri} -> {SecilenUcus.VarisSehri}";

            // Müşterinin sadece mesajı görmesini sağlamak için sayfayı yeniden yükle
            return RedirectToPage("./RezervasyonDetay", new { id = yeniRezervasyon.RezervasyonID }); // Yeni bir detay sayfasına yönlendireceğiz
        }
    }
}