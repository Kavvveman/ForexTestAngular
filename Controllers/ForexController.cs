using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;

namespace ForexTestAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForexController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly HttpClient _httpClient;

        private readonly string _apiUrl = "https://fcsapi.com/api-v3/forex/latest?id=1&access_key=K9izZeK9cwB2rKS86EalHszK";
        // GET: ForexController
        [HttpGet]
        public async Task<decimal> ConvertCurrencyAsync(string baseCurrency, string targetCurrency, decimal amount)
        {

            try
            {
                // Construct the API URL with base currency and target currency
                string apiUrl = _apiUrl;

                // Make GET request to the API endpoint
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                // Ensure the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the JSON response to a dynamic object
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    dynamic exchangeRates = JsonConvert.DeserializeObject(jsonResponse);

                    // Extract the exchange rate for the target currency
                    decimal rate = exchangeRates["rates"][targetCurrency];

                    // Calculate the converted amount
                    decimal convertedAmount = amount * rate;

                    // Return the converted amount
                    return convertedAmount;
                    //SetTextToDisplayConversion()
                }
                else
                {
                    Debug.WriteLine("Failed to fetch forex rates. Status code: " + response.StatusCode);
                    return -1; // Or throw an exception
                }
            }
            catch (Exception ex)
            {
              
                Console.WriteLine("An error occurred: " + ex.Message);
                return -1; // Or throw an exception
            }
        }
        [HttpGet]
        [Route("/Forex/ConvertCurr")]
        public decimal ConvertCurr(string baseCurrency , string targetCurrency, decimal amount)
        {

            // Example: Perform the conversion using ForexService
            var forexService = new ForexController();
            decimal convertedAmount = forexService.ConvertCurrencyAsync(baseCurrency, targetCurrency, amount).Result;

            ViewBag.ConvertedAmount = convertedAmount;
            return convertedAmount;
        }

        //public ActionResult GetLatestRates()
        //{
        //    static async Task FetchAndStoreForexRatesData()
        //    {

        //        string apiUrl = "https://fcsapi.com/api-v3/forex/latest?id=1&access_key=K9izZeK9cwB2rKS86EalHszK";

        //        using (HttpClient client = new HttpClient())
        //        {
        //            try
        //            {
        //                HttpResponseMessage response = await client.GetAsync(apiUrl);

        //                if (response.IsSuccessStatusCode)
        //                {
        //                    string responseBody = await response.Content.ReadAsStringAsync();
        //                    //FileStream uploadedfilestream;

        //                    await System.IO.File.WriteAllTextAsync(LocalFilePath, responseBody);

        //                    //FileStream uploadFileStream = System.IO.File.OpenRead(LocalFilePath);
        //                    //File.WriteAllText(responseBody, LocalFilePath);

        //                }
        //                else
        //                {
        //                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        //                }
        //            }
        //            catch (HttpRequestException e)
        //            {
        //                Console.WriteLine($"Request Exception: {e.Message}");
        //            }
        //        }
        //    }
        //    return View();
        //}

        // GET: ForexController/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ForexController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ForexController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ForexController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ForexController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ForexController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ForexController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
