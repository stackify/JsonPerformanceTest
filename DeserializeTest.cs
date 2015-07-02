using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonPerformanceTest.Models;
using Newtonsoft.Json;

namespace JsonPerformanceTest
{
    class DeserializeTest
    {
        static System.Text.Json.JsonParser jp = new JsonParser();

        public static void DoTests()
        {
            string json = EmbeddedJson.MonitorRecords;

            FastJsonParserTest(json);
            FastJsonParserGenericTest(json);
            NewtonsoftGenericTest(json);
            NewtonsoftMiniTest();
            NewtonsoftTest(json);
            ServiceStackMiniTest();
            ServiceStackTest(json);
        }

        public static void ServiceStackTest(string json)
        {
            ServiceStack.Text.JsonSerializer.DeserializeFromString<List<Monitor>>(json);
            ServiceStack.Text.JsonSerializer.DeserializeFromString<List<Monitor>>(json);
            ServiceStack.Text.JsonSerializer.DeserializeFromString<List<Monitor>>(json);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 25000; i++)
            {
                var monitors = ServiceStack.Text.JsonSerializer.DeserializeFromString<List<Monitor>>(json);
            }
            sw.Stop();

            Debug.WriteLine("ServiceStack read " + sw.ElapsedMilliseconds + "ms");
        }

        public static void ServiceStackMiniTest()
        {
            string json = EmbeddedJson.MonitorRecordsMini;
            ServiceStack.Text.JsonSerializer.DeserializeFromString<List<Monitor2>>(json);
            ServiceStack.Text.JsonSerializer.DeserializeFromString<List<Monitor2>>(json);
            ServiceStack.Text.JsonSerializer.DeserializeFromString<List<Monitor2>>(json);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 25000; i++)
            {
                var monitors = ServiceStack.Text.JsonSerializer.DeserializeFromString<List<Monitor2>>(json);
            }
            sw.Stop();

            Debug.WriteLine("ServiceStackMini read " + sw.ElapsedMilliseconds + "ms");
        }

        public static void FastJsonParserTest(string json)
        {
            jp.Parse<List<Monitor>>(json);
            jp.Parse<List<Monitor>>(json);
            jp.Parse<List<Monitor>>(json);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 25000; i++)
            {
                var monitors = jp.Parse<List<Monitor>>(json);
            }
            sw.Stop();

            Debug.WriteLine("FastJson read " + sw.ElapsedMilliseconds + "ms");
        }

        public static void FastJsonParserGenericTest(string json)
        {
            var obj = jp.Parse(json);
            jp.Parse(json);
            jp.Parse(json);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 25000; i++)
            {
                var monitors = jp.Parse(json);
            }
            sw.Stop();

            Debug.WriteLine("FastJsonGeneric read " + sw.ElapsedMilliseconds + "ms");
        }


        public static void NewtonsoftTest(string json)
        {
            JsonConvert.DeserializeObject<List<Monitor>>(json);
            JsonConvert.DeserializeObject<List<Monitor>>(json);
            JsonConvert.DeserializeObject<List<Monitor>>(json);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 25000; i++)
            {
                var monitors = JsonConvert.DeserializeObject<List<Monitor>>(json);
            }
            sw.Stop();
            
            Debug.WriteLine("Newtonsoft read " + sw.ElapsedMilliseconds + "ms");
        }

        public static void NewtonsoftGenericTest(string json)
        {
            JsonConvert.DeserializeObject(json);
            JsonConvert.DeserializeObject(json);
            JsonConvert.DeserializeObject(json);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 25000; i++)
            {
                var monitors = JsonConvert.DeserializeObject(json);
            }
            sw.Stop();

            Debug.WriteLine("NewtonsoftGeneric read " + sw.ElapsedMilliseconds + "ms");
        }

        public static void NewtonsoftMiniTest()
        {
            string json = EmbeddedJson.MonitorRecordsMini;

            JsonConvert.DeserializeObject<List<Monitor2>>(json);
            JsonConvert.DeserializeObject<List<Monitor2>>(json);
            JsonConvert.DeserializeObject<List<Monitor2>>(json);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 25000; i++)
            {
                var monitors = JsonConvert.DeserializeObject<List<Monitor2>>(json);
            }
            sw.Stop();

            Debug.WriteLine("NewtonsoftMini read " + sw.ElapsedMilliseconds + "ms");
        }

    }
}
