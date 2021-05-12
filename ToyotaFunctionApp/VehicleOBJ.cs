using System;
using System.Collections.Generic;
using System.Text;

namespace ToyotaFunctionApp
{
    public class VehicleOBJ
    {
        public string vin { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string body { get; set; }

        public int year { get; set; }
        public string transmission { get; set; }

        public List<Accessory> accessories { get; set; }

        //        {
        //    "vin": "JTEES42A082109390",
        //    "make": "Toyota",
        //    "model": "Highlander",
        //    "body": "4dr SUV",
        //    "year": 2020,
        //    "transmission": "automatic",
        //    {
        //        "accessories": [{
        //            assecoryid: "61a6e7c5-e5ec-ea11-a817-000d3a5bf119",
        //            accesorytype: "Exterior",
        //            accessoryname: "Alloy Wheel Locks"
        //        }, {
        //            assecoryid: "c14629eb-72ec-ea11-a817-000d3a5bf119",
        //            accesorytype: "Interior",
        //            accessoryname: "Frameless HomeLink Mirror"
        //        }]
        //    }
        //}
    }

    public class Accessory
    {
        public string assecoryid { get; set; }
        public string accesorytype { get; set; }
        public string accessoryname { get; set; }
    }
}
