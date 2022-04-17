using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MoveIT.PriceCalculator.Models;

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


            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<Price>( requestBody);

            var totalPrice = CalculateTotalPrice(data.Distance, data.LivingSpace, data.StorageSpace, data.HasHeavyItem);

            return new OkObjectResult(totalPrice);
        }

        public static decimal CalculateTotalPrice(int distance, int livingSpace, int storageSpace, bool hasHeavyItem)
        {
            var volumePrice = CalculateVolumePrice(distance, livingSpace, storageSpace);
            if (hasHeavyItem)
            {
                return volumePrice + 5000;
            }
            return volumePrice;
        }

        public static decimal CalculateVolumePrice(int distance, int livingSpace, int storageSpace)
        {
            var distancePrice = CalculateDistancePrice(distance);

            var totalSpace = livingSpace + storageSpace * 2;
            var numberOfCars = Math.Floor((decimal)totalSpace / 50) + 1;
            return numberOfCars * distancePrice; 
        }

        public static decimal CalculateDistancePrice(int distance)
        {
            switch (distance)
            {
                case < 50:
                    return 1000 + distance * 10;
                case >= 50 and < 100:
                    return 5000 + distance * 8;
                case >= 100:
                    return 10000 + distance * 7;
            }
        }
    }
}
