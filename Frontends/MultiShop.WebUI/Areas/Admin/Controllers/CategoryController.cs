using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.CategoryDTOs;
using System.Net;

namespace MultiShop.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class CategoryController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CategoryController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient("CatalogAPI");
        List<ResponseCategoryDTO> categories = new List<ResponseCategoryDTO>();
        try
        {
            // İstek gönderme denemesi
            HttpResponseMessage response = await client.GetAsync("Categories");

            // Başarılı bir yanıt geldiyse
            if (response.IsSuccessStatusCode)
            {
                // Kategorileri deserialize et
                List<ResponseCategoryDTO>? apiCategories =
                    await response.Content.ReadFromJsonAsync<List<ResponseCategoryDTO>>();

                // Null kontrolü yaparak boş listeyi ata
                categories = apiCategories ?? new List<ResponseCategoryDTO>();
            }
        }
        catch (Exception ex) { }

        return View(categories);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDTO model)
    {
        HttpClient client = _httpClientFactory.CreateClient("CatalogAPI");

        HttpResponseMessage? response = null;

        try
        {
            response = await client.PostAsJsonAsync("Categories", model);

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
            response = await client.DeleteAsync($"Categories/{id}");

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

        UpdateCategoryDTO? model = null;

        try
        {
            HttpResponseMessage response = await client.GetAsync($"Categories/{id}");

            if (response.IsSuccessStatusCode)
            {
                model = await response.Content.ReadFromJsonAsync<UpdateCategoryDTO>();

                if (model == null)
                {
                    return NotFound();
                }

                return View(model);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
        }
        catch (Exception ex)
        {
        }

        //return RedirectToAction(nameof(Index));
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Edit(UpdateCategoryDTO model)
    {
        HttpClient client = _httpClientFactory.CreateClient("CatalogAPI");
        HttpResponseMessage? response = null;

        try
        {
            response = await client.PutAsJsonAsync($"Categories/{model.CategoryID}", model);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
        }
        
        catch (Exception ex){}

        return View(model);
    }
}
