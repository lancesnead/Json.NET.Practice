using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;
using System.Data;

namespace JsonNetPractice
{
    partial class Program
    {
        static void Main(string[] args)
        {

            ////Serialize an Object
            //Account account = new Account
            //{
            //    Email = "lance.snead@gmail.com",
            //    Active = true,
            //    CreatedDate = new DateTime(2019, 06, 24),
            //    Roles = new List<string>
            //    {
            //        "User",
            //        "Admin"
            //    }
            //};

            //string json = JsonConvert.SerializeObject(account, Formatting.Indented);
            //Console.WriteLine(json);

            ////Serilaize JSON to file
            //Movie movie = new Movie
            //{
            //    Name = "Bad Boys",
            //    Year = 1995
            //};


            ////serialize JSON to a string then write string to a file
            //File.WriteAllText(@"c:\movie.json", JsonConvert.SerializeObject(movie));

            ////serialize JSON directly to file
            //using (StreamWriter file = File.CreateText(@"c:\movie2.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(file, movie);
            //}

            ////Serialize with JsonConverters
            //List<StringComparison> stringComparisons = new List<StringComparison>
            //{
            //    StringComparison.CurrentCulture,
            //    StringComparison.Ordinal
            //};

            //string jsonWithoutConverter = JsonConvert.SerializeObject(stringComparisons);

            //Console.WriteLine(jsonWithoutConverter);
            //// [0,4]

            //string jsonWithConverter = JsonConvert.SerializeObject(stringComparisons, new StringEnumConverter());

            //Console.WriteLine(jsonWithConverter);
            //// ["CurrentCulture", "Ordinal"]

            //List<StringComparison> newStringComparisons = JsonConvert.DeserializeObject<List<StringComparison>>(
            //    jsonWithConverter,
            //    new StringEnumConverter());

            //Console.WriteLine(string.Join(", ", newStringComparisons.Select(c => c.ToString()).ToArray()));
            //// CurrentCulture, Ordinal

            //Serialize a DataSet
            DataSet dataSet = new DataSet("dataSet");
            dataSet.Namespace = "NetFrameWork";
            DataTable table = new DataTable();
            DataColumn idColumn = new DataColumn("id", typeof(int));
            idColumn.AutoIncrement = true;

            DataColumn itemColumn = new DataColumn("item");
            table.Columns.Add(idColumn);
            table.Columns.Add(itemColumn);
            dataSet.Tables.Add(table);

            for (int i = 0; i < 2; i++)
            {
                DataRow newRow = table.NewRow();
                newRow["item"] = "item " + i;
                table.Rows.Add(newRow);
            }

            dataSet.AcceptChanges();

            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

            Console.WriteLine(json);
            // {
            //   "Table1": [
            //     {
            //       "id": 0,
            //       "item": "item 0"
            //     },
            //     {
            //       "id": 1,
            //       "item": "item 1"
            //     }
            //   ]
            // }
            Console.ReadKey();


        } 
    }
}
