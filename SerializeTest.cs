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
    class SerializeTest
    {
        static System.Text.Json.JsonParser jp = new JsonParser();

        public static void DoTests()
        {
            //Monitors2 is being loaded the same way, but will serialize differently since it is Monitor2
            //It has the field aliases

            var monitors = JsonConvert.DeserializeObject<List<Monitor>>(EmbeddedJson.MonitorRecords);

            //Deserializing with this parser since it ignores the column names.
            var monitors2 = jp.Parse<List<Monitor2>>(EmbeddedJson.MonitorRecords);
            
            ServiceStackTest(monitors);
            ServiceStackMiniTest(monitors2);
            NewtonsoftTest(monitors);
            NewtonsoftGenericTest();
            NewtonsoftTestMini(monitors2);
            DataContractSerializerTest(monitors);
        }

  

        public static void ServiceStackTest(object toSerialize)
        {
            ServiceStack.Text.JsonSerializer.SerializeToString(toSerialize);
            ServiceStack.Text.JsonSerializer.SerializeToString(toSerialize);
            ServiceStack.Text.JsonSerializer.SerializeToString(toSerialize);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 25000; i++)
            {
                var json = ServiceStack.Text.JsonSerializer.SerializeToString(toSerialize);
            }
            sw.Stop();

            Debug.WriteLine("ServiceStack serialize " + sw.ElapsedMilliseconds + "ms");
        }

        public static void ServiceStackMiniTest(object toSerialize)
        {
            var test = ServiceStack.Text.JsonSerializer.SerializeToString(toSerialize);
            ServiceStack.Text.JsonSerializer.SerializeToString(toSerialize);
            ServiceStack.Text.JsonSerializer.SerializeToString(toSerialize);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 25000; i++)
            {
                var json = ServiceStack.Text.JsonSerializer.SerializeToString(toSerialize);
            }
            sw.Stop();

            Debug.WriteLine("ServiceStackMini serialize " + sw.ElapsedMilliseconds + "ms");
        }

        public static void NewtonsoftGenericTest()
        {
            var toSerialize = JsonConvert.DeserializeObject(EmbeddedJson.MonitorRecords);

            JsonConvert.SerializeObject(toSerialize);
            JsonConvert.SerializeObject(toSerialize);
            JsonConvert.SerializeObject(toSerialize);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 25000; i++)
            {
                var json = JsonConvert.SerializeObject(toSerialize);
            }
            sw.Stop();

            Debug.WriteLine("NewtonsoftGeneric serialize " + sw.ElapsedMilliseconds + "ms");
        }


        public static void NewtonsoftTest(object toSerialize)
        {
            JsonConvert.SerializeObject(toSerialize);
            JsonConvert.SerializeObject(toSerialize);
            JsonConvert.SerializeObject(toSerialize);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 25000; i++)
            {
                var json = JsonConvert.SerializeObject(toSerialize);
            }
            sw.Stop();

            Debug.WriteLine("Newtonsoft serialize " + sw.ElapsedMilliseconds + "ms");
        }


        public static void NewtonsoftTestMini(object toSerialize)
        {
            JsonConvert.SerializeObject(toSerialize);
            JsonConvert.SerializeObject(toSerialize);
            JsonConvert.SerializeObject(toSerialize);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 25000; i++)
            {
                var json = JsonConvert.SerializeObject(toSerialize);
            }
            sw.Stop();

            Debug.WriteLine("NewtonsoftTestMini serialize " + sw.ElapsedMilliseconds + "ms");
        }

        public static void DataContractSerializerTest(object toSerialize)
        {
            DataContractSerializerDoIt(toSerialize);
            DataContractSerializerDoIt(toSerialize);
            DataContractSerializerDoIt(toSerialize);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 25000; i++)
            {
                DataContractSerializerDoIt(toSerialize);
            }
            sw.Stop();

            Debug.WriteLine("DataContractJson serialize " + sw.ElapsedMilliseconds + "ms");
        }

        public static string DataContractSerializerDoIt(object toSerialize)
        {
            string json;
            using (MemoryStream stream1 = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Monitor>));

                ser.WriteObject(stream1, toSerialize);

                stream1.Position = 0;
                StreamReader sr = new StreamReader(stream1);
               json = sr.ReadToEnd();
                sr.Close();
            }
            return json;
        }
    }
}
