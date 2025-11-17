using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DTOLayer.CatalogDTOs.CategoryDTOs;
using MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;
using System.Net;

namespace MultiShop.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class ProductController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient("CatalogAPI");
        List<ResponseProductDTO> products = new List<ResponseProductDTO>();
        try
        {
            HttpResponseMessage response = await client.GetAsync("Products");

            if (response.IsSuccessStatusCode)
            {
                List<ResponseProductDTO>? apiProducts =
                    await response.Content.ReadFromJsonAsync<List<ResponseProductDTO>>();

                products = apiProducts ?? new List<ResponseProductDTO>();
            }
        }
        catch (Exception ex) { }

        return View(products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        HttpClient client = _httpClientFactory.CreateClient("CatalogAPI");
        List<ResponseCategoryDTO> categories = new List<ResponseCategoryDTO>();
        try
        {
            HttpResponseMessage response = client.GetAsync("Categories").Result;
            if (response.IsSuccessStatusCode)
            {
                List<ResponseCategoryDTO>? apiCategories =
                    response.Content.ReadFromJsonAsync<List<ResponseCategoryDTO>>().Result;
                categories = apiCategories ?? new List<ResponseCategoryDTO>();

                List<SelectListItem> selectListItems = categories
                    .Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.CategoryID
                    }).ToList();
                ViewBag.Categories = selectListItems;
                return View();
            }
        }
        catch (Exception ex) { }

        List<ResponseCategoryDTO> categoriess = new List<ResponseCategoryDTO>
{
    new ResponseCategoryDTO { CategoryID = "1", Name = "Elektronik" },
    new ResponseCategoryDTO { CategoryID = "2", Name = "Giyim" },
    new ResponseCategoryDTO { CategoryID = "3", Name = "Ev & Yaşam" },
    new ResponseCategoryDTO { CategoryID = "4", Name = "Kitap" }
};

        List<SelectListItem> selectListItemss = categoriess
    .Select(c => new SelectListItem
    {
        Text = c.Name,         // Kullanıcının göreceği metin
        Value = c.CategoryID.ToString() // Arka planda kullanılacak değer (string olmalı)
    }).ToList();

        ViewBag.Categories = selectListItemss;

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDTO model)
    {
        HttpClient client = _httpClientFactory.CreateClient("CatalogAPI");

        HttpResponseMessage? response = null;

        try
        {
            response = await client.PostAsJsonAsync("Products", model);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
        }
        catch (Exception ex) { }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken] // Güvenlik için önemlidir
    public async Task<IActionResult> Delete(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient("CatalogAPI");

        HttpResponseMessage? response = null;

        try
        {
            response = await client.DeleteAsync($"Products/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
        }
        catch (Exception ex) { }
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        HttpClient client = _httpClientFactory.CreateClient("CatalogAPI");

        UpdateProductDTO? model = null;

        try
        {
            HttpResponseMessage response = await client.GetAsync($"Products/{id}");

            if (response.IsSuccessStatusCode)
            {
                model = await response.Content.ReadFromJsonAsync<UpdateProductDTO>();

                // Veri null gelirse veya deserialization hatası olursa
                if (model == null)
                {
                    // Loglama yapın: "Veri 200 OK döndü ancak null/boştu."
                    return NotFound(); // Veya hata sayfasına yönlendirin
                }

                return View(model);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                // 4. API'den 404 Not Found Hatası Geldi
                return NotFound(); // Kullanıcıya bu ID'de öğe olmadığını bildirin.
            }
        }
        catch (Exception ex)
        {
            // Loglama yapın: ex.Message
        }

        //return RedirectToAction(nameof(Index));
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Edit(UpdateProductDTO model)
    {
        HttpClient client = _httpClientFactory.CreateClient("CatalogAPI");

        HttpResponseMessage? response = null;

        try
        {
            response = await client.PutAsJsonAsync($"Products/{model.ProductID}", model);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        catch (Exception ex) { }

        return View(model);
    }
}
