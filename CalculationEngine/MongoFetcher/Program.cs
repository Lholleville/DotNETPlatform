using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

//Extra NuGet Imports 
using MongoDB.Bson;
using MongoDB.Driver;
using MongoFetcher.MyEngine;
using Newtonsoft.Json.Linq;
using MongoDB.Bson.IO;

namespace MongoFetcher
{
    class Program
    {
        static void Main(string[] args)
        {
            //Init the WCF Calculation Engine 
            CalculationEngineClient MyEngine = new CalculationEngineClient();

            //MongoDB connector
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("devices");
            var collec = database.GetCollection<BsonDocument>("data");
            var collec1 = database.GetCollection<BsonDocument>("deviceList");


            //Temporary Database Populator
            // Setting up variables
            DateTime date1 = DateTime.Now;
            Random rnd = new Random();

            int MyID = 1;
            while (MyID < 3)
            {
                //making a device manifest for the deviceNum database
                var documntDevice = new BsonDocument
                {
                    { "IdDevice", MyID },
                    { "Name", "Bidule "+ MyID },
                    { "Mac","00:1B:44:11:3A:B7" },
                    { "Type","1"},
                    { "DateAdded", date1.ToString("dd/mm/yy HH:mm:ss")}
                };
                //Actual insertion of the data in the database
                collec1.InsertOneAsync(documntDevice);

                //DB Population loop
                //generates 5 entries in the database

                for (double i = 0; i < 2; i++)
                {
                    double gaben = (i + 1) * 100;

                    var documnt = new BsonDocument
                    {
                        { "IdDevice", MyID },
                        { "Date", date1.ToString("dd/mm/yy HH:mm:ss")},
                        { "NoV", 1},
                        { "Value", gaben},
                        { "Value2",  gaben }
                    };
                    //Actual insertion of the data in the database
                    collec.InsertOneAsync(documnt);
                }
                MyID++;
            }

            //One of My debugging Text Strings Don't mind me
            //Console.WriteLine("Ok I'm done here");

            //Getting the entire database in a variable
            var doc = collec.Find(new BsonDocument()).ToList();

            //Setting up the Table that will be sent to the Calculation engine
            double[] myTable = new double[doc.Count];

            //Stripping all content from the doc variable into the new Table
            for (int i = 0; i < doc.Count; i++)
            {
                //One of My debugging Text Strings Don't mind me
                /*Console.WriteLine(doc[i].ToJson());*/

                //forcing Json Settings for parsing
                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part

                //creating an object to parse the values into the Tables
                dynamic data = JObject.Parse(doc[i].ToJson(jsonWriterSettings));

                //One of My debugging Text Strings Don't mind me
                /*Console.WriteLine(data.Value);*/

                //putting the Values into the table
                myTable[i] = data.Value;
            }
            //Pushing the table straight into the WCF function
            Console.WriteLine(MyEngine.Averager(myTable));

            //Console read for good measure so you can see it actually working.
            Console.Read();
        }
    }
}