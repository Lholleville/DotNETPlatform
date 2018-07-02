using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

//Extra NuGet Imports 
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using MongoDB.Bson.IO;


namespace CalculationEngine
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "CalculationEngine" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez CalculationEngine.svc ou CalculationEngine.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class CalculationEngine : ICalculationEngine
    {


        public double Averager(double[] MyTable, int deviceType )
        {
            double MyResult = MyTable.Average();
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = 2147483647;

            //MongoDB connector
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("devices");
            var collec = database.GetCollection<BsonDocument>("CalculatedMetrics");

            DateTime date1 = DateTime.Now;

            var documntDevice = new BsonDocument
            {
                { "DeviceType", deviceType  },
                { "Average", MyResult},
                { "Max", MyTable.Max() },
                { "Min", MyTable.Min() },
                { "TimeStamp", date1.ToString("dd/mm/yy HH:mm:ss")}
            };

            return MyResult;
        }
    }
}
