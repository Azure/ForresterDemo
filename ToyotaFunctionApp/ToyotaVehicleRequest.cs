using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ToyotaFunctionApp
{
    public static class VehicleRequest
    {
        [OpenApiOperation(operationId: nameof(GetVehicleRequest),Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(HttpStatusCode.OK,"application/json",typeof(VehicleOBJ[]))]
        
        [FunctionName(nameof(GetVehicleRequest))]
        public static async Task<IActionResult> GetVehicleRequest(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string vinId = req.Query["VIN"];
            string model = req.Query["model"];
            model = string.IsNullOrEmpty(model) ? "Highlander" : model;

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            vinId = vinId ?? data?.name;

            var accessories = new List<Accessory>() {
                new Accessory(){ assecoryid = Guid.NewGuid().ToString(), accesorytype="Exterior" , accessoryname ="Alloy Wheel Locks"},
                new Accessory(){ assecoryid = Guid.NewGuid().ToString(), accesorytype="Exterior" , accessoryname ="Ball Mount"},
                new Accessory(){ assecoryid = Guid.NewGuid().ToString(), accesorytype="Exterior" , accessoryname ="Blackout Emblem Overlays"},
                new Accessory(){ assecoryid = Guid.NewGuid().ToString(), accesorytype="Interior" , accessoryname ="Frameless HomeLink Mirror"},
                new Accessory(){ assecoryid = Guid.NewGuid().ToString(), accesorytype="Interior" , accessoryname ="All-Weather Floor Liners"},
                new Accessory(){ assecoryid = Guid.NewGuid().ToString(), accesorytype="Interior" , accessoryname ="Cargo Cover"},
            };

            VehicleOBJ vehicleObj = new VehicleOBJ();
            if (string.IsNullOrEmpty(vinId))
            {
                vehicleObj.vin = "JTEES42A082109390";
                vehicleObj.make = "Toyota";
                vehicleObj.model = "Highlander";
                vehicleObj.body = "4dr SUV";
                vehicleObj.year = 2021;
                vehicleObj.transmission = "automatic";
                vehicleObj.accessories = accessories;
            }
            else
            {
                vehicleObj.vin = vinId;
                vehicleObj.make = "Toyota";
                vehicleObj.model = model;
                vehicleObj.body = "4dr SUV";
                vehicleObj.year = 2021;
                vehicleObj.transmission = "automatic";
                vehicleObj.accessories = accessories;
            }
            return new OkObjectResult(vehicleObj);
        }
    }
}
