using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace JsonPerformanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializeTest.DoTests();
            DeserializeTest.DoTests();
        }

        static void DoIt()
        {
            try
            {
                throw new InvalidOperationException("Boom");
            }
            catch (Exception)
            {

            }
        }
    }
}
