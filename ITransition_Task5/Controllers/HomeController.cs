using System.Diagnostics;
using System.Globalization;
using CsvHelper;
using ITransition_Task5.Helpers;
using ITransition_Task5.Models;
using ITransition_Task5.Models.Entities;
using ITransition_Task5.Models.Enums;
using ITransition_Task5.Models.ViewModels;
using ITransition_Task5.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITransition_Task5.Controllers
{
    public class HomeController(IUserDataService service) : Controller
    {
        const int PageSize = 20;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetData(DataRequestModel requestModel)
        {
            var regionEnum = (Region)requestModel.Region;

            var data = service.GetUserData(
                requestModel.Seed,
                requestModel.MistakesRate,
                regionEnum.ToString() // "Ru", "EnUs", "De", "Fr"
            );

            return Json(data.Skip((requestModel.PageNumber - 1) * PageSize).Take(PageSize));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCsv([FromBody] IEnumerable<User> persons)
        {
            var path = $"{Directory.GetCurrentDirectory()}{DateTime.Now.Ticks}.csv";
            await using var writer = new StreamWriter(path);

            await using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.Context.RegisterClassMap<DataCsvMap>();
                await csvWriter.WriteRecordsAsync(persons);
            }

            return PhysicalFile(path, "text/csv");
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
