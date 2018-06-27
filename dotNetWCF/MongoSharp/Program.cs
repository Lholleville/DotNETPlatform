using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("startup");
            var collec = database.GetCollection<BsonDocument>("employee");

            var documnt = new BsonDocument
            {
                { "name","Max" },
                {"Age","28"},
                {"salary", "1200"},
                {"position","Tester"}

            };
            collec.InsertOneAsync(documnt);
            Console.Write("Ok I'm done here");

            Console.Read();
           
        }
    }
}
