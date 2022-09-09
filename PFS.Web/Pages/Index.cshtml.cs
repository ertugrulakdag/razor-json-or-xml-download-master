using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace PFS.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPostJson()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var products = Data.Product.GetProduct();
            var jsonObject = JsonConvert.SerializeObject(products);
            var fileName = "products.json";
            byte[] bytes = Encoding.UTF8.GetBytes(jsonObject);

            var content = new MemoryStream(bytes);
            return File(content, "application/json", fileName);

        }
        public IActionResult OnPostXml()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var products = Data.Product.GetProduct();

            var writer = new System.Xml.Serialization.XmlSerializer(products.GetType());
            var stream = new MemoryStream();
            writer.Serialize(stream, products);

            var fileName = "products.xml";
            return File(stream.ToArray(), "application/xml", fileName);
        }
    }
}
