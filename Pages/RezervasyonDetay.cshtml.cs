using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UcakBiletiSistemi.Models;
using UcakBiletiSistemi.Yonetim;

namespace UcakBiletiSistemi.Pages
{
    public class RezervasyonDetayModel : PageModel
    {
        // URL'den gelecek Rezervasyon ID'sini yakalar
        public Rezervasyon? RezervasyonDetay { get; set; }

        // OnGet metodu sayfa URL ile çağrıldığında çalışır
        public IActionResult OnGet(int id) 
        {
            // RezervasyonYoneticisi'nden bu ID'ye ait rezervasyonu bulma metodu (Bu metodu eklememiz GEREKİYOR!)
            RezervasyonDetay = RezervasyonYoneticisi.RezervasyonBul(id);

            if (RezervasyonDetay == null)
            {
                return NotFound(); 
            }

            return Page();
        }
    }
}