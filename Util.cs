using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Xml.Linq;

using Serilog;
using Serilog.Debugging;
using System.IO;

namespace Util {

    public static class ContractLog {

        public static void Init(string file = "log.txt") {

            File.Delete(file);
            SelfLog.Enable(Console.Out);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("log.txt")
                .CreateLogger();
        }

        public static void Close() {
            Log.CloseAndFlush();
        }
    }

    public class Usd {
        public int integerPart { get; }
        public int fractPart { get; }

        public Usd( int _integerPart, int _fractPart ) {
            integerPart = _integerPart;
            fractPart = _fractPart;
        }
    }

    public static class CrbCourseXmlParser {

        public static Usd UsdRate(XDocument xml, string tagRub="Value") {

            string rubRate = null;

            foreach (XNode node in xml.DescendantNodes())
            {
                if (node is XElement)
                {
                    XElement element = (XElement)node;
                    if (element.Name.LocalName.Equals(tagRub))
                        rubRate = element.Value;
                }
            }

            if (rubRate == null) throw new Exception($"No tag \"{tagRub}\" inside xml!");

            double rub = Double.Parse(rubRate);
            int integerPart = (int) rub;
            int fractPart = (int) (10000 * (rub - (double)integerPart));

            return new Usd(integerPart, fractPart);
        }
    }

    public static class Date {
        public static string Now() {

            var now   = DateTime.Now;
            var day   = now.Day;
            var month = now.Month;
            var year  = now.Year;

            var date = $"{day}/{month}/{year}";

            return date;
        }
    }
}