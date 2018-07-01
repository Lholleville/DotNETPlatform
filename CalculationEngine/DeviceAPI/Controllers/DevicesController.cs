using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DeviceAPI.Models;

//Extra NuGet Imports 
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using MongoDB.Bson.IO;

namespace DeviceAPI.Controllers
{
    public class DevicesController : ApiController
    {
        DateTime date1 = DateTime.Now;
        public List<Devices> listDevices = new List<Devices>();

        /// <summary>
        /// Retrieves the list of Saved Devices
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/Devices")]
        public IEnumerable<Devices> GetAllDevices()
        {
            //MongoDB connector
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("devices");
            var collec = database.GetCollection<BsonDocument>("data");
            var collec1 = database.GetCollection<BsonDocument>("deviceList");
            //Fetching data as lists
            var doc = collec.Find(new BsonDocument()).ToList();
            var doc1 = collec1.Find(new BsonDocument()).ToList();

            //clearing the list device List just in case
            listDevices.Clear();

            //forcing Json Settings for parsing
            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part

            for (int j = 0; j < doc1.Count; j++)
            {
                for (int i = 0; i < doc.Count; i++)
                {
                    //creating an object to parse the values into the Tables
                    dynamic data1 = JObject.Parse(doc1[j].ToJson(jsonWriterSettings));
                    dynamic data = JObject.Parse(doc[i].ToJson(jsonWriterSettings));

                    Console.WriteLine(data1.IdDevice);
                    Console.WriteLine(data1.Name);
                    Console.WriteLine(data1.Mac);
                    Console.WriteLine(data.NoV);
                    Console.WriteLine(data.Value);
                    Console.WriteLine(data.Value2);


                    bool alreadyExist = listDevices.Any(item => item.IdDevice == (double)data.IdDevice);
                    bool alreadyExist1 = listDevices.Any(item => item.IdDevice == (double)data1.IdDevice);


                    if (data.Old == false && alreadyExist == false && alreadyExist1 == false)
                    {
                        //putting the Values into the table 
                        listDevices.Add(new Devices() { IdDevice = data1.IdDevice, Name = (String)data1.Name, Mac = (String)data1.Mac, NoV = (double)data.NoV, Value = (double)data.Value, Value2 = (double)data.Value2, Old = data.Old });
                    }

                }
            }
            return listDevices;
        }

        /// <summary>
        /// Gives Information about the selected device
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/Devices/{dev}")]
        public IHttpActionResult GetDeviceInfo(long dev)
        {
            //MongoDB connector
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("devices");
            var collec = database.GetCollection<BsonDocument>("data");
            var collec1 = database.GetCollection<BsonDocument>("deviceList");
            //Fetching data as lists
            var doc = collec.Find(new BsonDocument()).ToList();
            var doc1 = collec1.Find(new BsonDocument()).ToList();

            //clearing the list device List just in case
            listDevices.Clear();

            //forcing Json Settings for parsing
            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part

            for (int j = 0; j < doc1.Count; j++)
            {
                for (int i = 0; i < doc.Count; i++)
                {
                    //creating an object to parse the values into the Tables
                    dynamic data1 = JObject.Parse(doc1[j].ToJson(jsonWriterSettings));
                    dynamic data = JObject.Parse(doc[i].ToJson(jsonWriterSettings));

                    Console.WriteLine(data1.IdDevice);
                    Console.WriteLine(data1.Name);
                    Console.WriteLine(data1.Mac);
                    Console.WriteLine(data.NoV);
                    Console.WriteLine(data.Value);
                    Console.WriteLine(data.Value2);


                    bool alreadyExist = listDevices.Any(item => item.IdDevice == (double)data.IdDevice);
                    bool alreadyExist1 = listDevices.Any(item => item.IdDevice == (double)data1.IdDevice);


                    if (data.Old == false && alreadyExist == false && alreadyExist1 == false)
                    {
                        //putting the Values into the table 
                        listDevices.Add(new Devices() { IdDevice = data1.IdDevice, Name = (String)data1.Name, Mac = (String)data1.Mac, NoV = (double)data.NoV, Value = (double)data.Value, Value2 = (double)data.Value2, Old = data.Old });
                    }

                }
            }
            var deviceInfo = listDevices.FirstOrDefault(c => c.IdDevice == dev);

            if (deviceInfo == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(deviceInfo);
        }

        /// <summary>
        /// Add a Device
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/v1/Devices")]
        public IHttpActionResult AddDevice(Devices DeviceInfo)
        {
            //MongoDB connector
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("devices");
            var collec = database.GetCollection<BsonDocument>("data");
            var collec1 = database.GetCollection<BsonDocument>("deviceList");
            //Fetching data as lists
            var doc = collec.Find(new BsonDocument()).ToList();
            var doc1 = collec1.Find(new BsonDocument()).ToList();

            //clearing the list device List just in case
            listDevices.Clear();

            //forcing Json Settings for parsing
            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part

            for (int j = 0; j < doc1.Count; j++)
            {
                for (int i = 0; i < doc.Count; i++)
                {
                    //creating an object to parse the values into the Tables
                    dynamic data1 = JObject.Parse(doc1[j].ToJson(jsonWriterSettings));
                    dynamic data = JObject.Parse(doc[i].ToJson(jsonWriterSettings));

                    Console.WriteLine(data1.IdDevice);
                    Console.WriteLine(data1.Name);
                    Console.WriteLine(data1.Mac);
                    Console.WriteLine(data.NoV);
                    Console.WriteLine(data.Value);
                    Console.WriteLine(data.Value2);


                    bool alreadyExist = listDevices.Any(item => item.IdDevice == (double)data.IdDevice);
                    bool alreadyExist1 = listDevices.Any(item => item.IdDevice == (double)data1.IdDevice);


                    if (data.Old == false && alreadyExist == false && alreadyExist1 == false)
                    {
                        //putting the Values into the table 
                        listDevices.Add(new Devices() { IdDevice = data1.IdDevice, Name = (String)data1.Name, Mac = (String)data1.Mac, NoV = (double)data.NoV, Value = (double)data.Value, Value2 = (double)data.Value2, Old = data.Old });
                    }

                }
            }
            var IdDevice = listDevices.Count() + 1;


            DeviceInfo.IdDevice = IdDevice;

            var documntDevice = new BsonDocument
                {
                    { "IdDevice", DeviceInfo.IdDevice },
                    { "Name", DeviceInfo.Name},
                    { "Mac", DeviceInfo.Mac},
                    { "Type",DeviceInfo.Type},
                    { "DateAdded", date1.ToString("dd/mm/yy HH:mm:ss")}
                };
            collec1.InsertOneAsync(documntDevice);
            listDevices.Add(DeviceInfo);
            var documnt = new BsonDocument
                    {
                        { "IdDevice", DeviceInfo.IdDevice},
                        { "Date", date1.ToString("dd/mm/yy HH:mm:ss")},
                        { "NoV", DeviceInfo.NoV },
                        { "Value", DeviceInfo.Value},
                        { "Value2",  DeviceInfo.Value2 },
                        { "Old", false}
                    };
            collec.InsertOneAsync(documnt);

            return Ok(DeviceInfo);
        }

        /// <summary>
        /// Modifies the Device information
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("api/v1/Devices")]
        public HttpResponseMessage UpdateDeviceInfo(Devices device)
        {
            //MongoDB connector
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("devices");
            var collec = database.GetCollection<BsonDocument>("data");
            var collec1 = database.GetCollection<BsonDocument>("deviceList");
            //Fetching data as lists
            var doc = collec.Find(new BsonDocument()).ToList();
            var doc1 = collec1.Find(new BsonDocument()).ToList();

            //clearing the list device List just in case
            listDevices.Clear();

            //forcing Json Settings for parsing
            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part

            for (int j = 0; j < doc1.Count; j++)
            {
                for (int i = 0; i < doc.Count; i++)
                {
                    //creating an object to parse the values into the Tables
                    dynamic data1 = JObject.Parse(doc1[j].ToJson(jsonWriterSettings));
                    dynamic data = JObject.Parse(doc[i].ToJson(jsonWriterSettings));

                    Console.WriteLine(data1.IdDevice);
                    Console.WriteLine(data1.Name);
                    Console.WriteLine(data1.Mac);
                    Console.WriteLine(data.NoV);
                    Console.WriteLine(data.Value);
                    Console.WriteLine(data.Value2);


                    bool alreadyExist = listDevices.Any(item => item.IdDevice == (double)data.IdDevice);
                    bool alreadyExist1 = listDevices.Any(item => item.IdDevice == (double)data1.IdDevice);


                    if (data.Old == false && alreadyExist == false && alreadyExist1 == false)
                    {
                        //putting the Values into the table 
                        listDevices.Add(new Devices() { IdDevice = data1.IdDevice, Name = (String)data1.Name, Mac = (String)data1.Mac, NoV = (double)data.NoV, Value = (double)data.Value, Value2 = (double)data.Value2, Old = data.Old });
                    }

                }
            }
            Devices devices = listDevices.FirstOrDefault(c => c.IdDevice == device.IdDevice);

            if (devices == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            collec.UpdateMany(Builders<BsonDocument>.Filter.Eq("IdDevice", device.IdDevice), Builders<BsonDocument>.Update.Set("Old", true));

            var documnt = new BsonDocument
                    {
                        { "IdDevice", device.IdDevice },
                        { "Date", date1.ToString("dd/mm/yy HH:mm:ss")},
                        { "NoV", device.NoV},
                        { "Value", device.Value},
                        { "Value2",  device.Value2 },
                        { "Old", false}
                    };
            collec.InsertOneAsync(documnt);

            if (device.Name != null || device.Mac != null)
            {
                devices.Mac = device.Mac;
                devices.NoV = device.NoV;
            }
            devices.Value = device.Value;
            device.Value2 = device.Value2;

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Deletes a device from the list
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/v1/Devices/{deviceID}")]
        public HttpResponseMessage DeleteDevice(int deviceID)
        {
            //MongoDB connector
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("devices");
            var collec = database.GetCollection<BsonDocument>("data");
            var collec1 = database.GetCollection<BsonDocument>("deviceList");
            //Fetching data as lists
            var doc = collec.Find(new BsonDocument()).ToList();
            var doc1 = collec1.Find(new BsonDocument()).ToList();

            //clearing the list device List just in case
            listDevices.Clear();

            //forcing Json Settings for parsing
            var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part

            for (int j = 0; j < doc1.Count; j++)
            {
                for (int i = 0; i < doc.Count; i++)
                {
                    //creating an object to parse the values into the Tables
                    dynamic data1 = JObject.Parse(doc1[j].ToJson(jsonWriterSettings));
                    dynamic data = JObject.Parse(doc[i].ToJson(jsonWriterSettings));

                    Console.WriteLine(data1.IdDevice);
                    Console.WriteLine(data1.Name);
                    Console.WriteLine(data1.Mac);
                    Console.WriteLine(data.NoV);
                    Console.WriteLine(data.Value);
                    Console.WriteLine(data.Value2);


                    bool alreadyExist = listDevices.Any(item => item.IdDevice == (double)data.IdDevice);
                    bool alreadyExist1 = listDevices.Any(item => item.IdDevice == (double)data1.IdDevice);


                    if (data.Old == false && alreadyExist == false && alreadyExist1 == false)
                    {
                        //putting the Values into the table 
                        listDevices.Add(new Devices() { IdDevice = data1.IdDevice, Name = (String)data1.Name, Mac = (String)data1.Mac, NoV = (double)data.NoV, Value = (double)data.Value, Value2 = (double)data.Value2, Old = data.Old });
                    }

                }
            }
            Devices device = listDevices.FirstOrDefault(c => c.IdDevice == deviceID);

            if (device == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            listDevices.Remove(device);
            collec.DeleteMany(Builders<BsonDocument>.Filter.Eq("IdDevice", device.IdDevice));
            collec1.DeleteMany(Builders<BsonDocument>.Filter.Eq("IdDevice", device.IdDevice));

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
