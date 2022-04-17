using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MoveIT.PriceCalculator
{
    public static class CalculatePriceFunction
    {
        [FunctionName("CalculatePriceFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string distance = req.Query["distance"];
            string livingSpace = req.Query["livingspace"];
            string storageSpace = req.Query["storagespace"];
            string hasHeavyItem = req.Query["heavyitem"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            distance = distance ?? data?.distance;
            livingSpace = livingSpace ?? data?.livingspace;
            storageSpace = storageSpace ?? data?.livingspace;
            hasHeavyItem = Convert.ToBoolean(hasHeavyItem ?? data?.hasheavyitem);

            string responseMessage = string.IsNullOrEmpty(distance)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, the distance is: {distance}.";

            return new OkObjectResult(responseMessage);
        }
    }
}
