using ConfigurationDemo.Abstraction;
using ConfigurationDemo.Builder;
using ConfigurationDemo.Source;
using System;
using System.Collections.Generic;

namespace ConfigurationDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> source = new Dictionary<string, string>
            {
                ["Format:DateTime:LongDatePattern"] = "dddd, MMMM d, yyyy",
                ["Format:DateTime:LongTimePattern"] = "h:mm:ss tt",
                ["Format:DateTime:ShortDatePattern"] = "M/d/yyyy",
                ["Format:DateTime:ShortTimePattern"] = "h:mm tt",

                ["Format:CurrencyDecimal:Digits"] = "2",
                ["Format:CurrencyDecimal:Symbol"] = "$",
            };

            MemoryConfigurationSource memSource = new MemoryConfigurationSource();
            memSource.InitialData = source;

          //  var ss = new MemoryConfigurationProvider(memSource);


            IConfiguration configuration = new ConfigurationBuilder().Add(memSource).Build();


            var data = configuration.GetSection("Format:DateTime:LongDatePattern").Value;
            var data2 = configuration.GetSection("Format:CurrencyDecimal:Digits").Value;

            Console.WriteLine("Hello World!");
        }
    }
}
