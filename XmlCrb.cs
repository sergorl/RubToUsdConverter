using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System.Net.Http;
using System.Text;
using System.Xml.Linq;
using Serilog;
using Serilog.Debugging;


namespace CourseRate {
    public class Crb
    {
        static readonly HttpClient client = new HttpClient();   
        string date {get; }

        public Crb(string _date) {
            date = _date;
        }

        public XDocument Xml()
        {
            Task<string> task = HttpResponse(date);
            var text = task.GetAwaiter().GetResult();

            XDocument xml = XDocument.Parse (text);
            
            return xml;
        }

        static async Task<string> HttpResponse(string date)
        {
            string url = $"http://www.cbr.ru/scripts/XML_dynamic.asp?date_req1={date}&date_req2={date}&VAL_NM_RQ=R01235";

            try	
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                byte[] bytes = await response.Content.ReadAsByteArrayAsync();

                Encoding encoding = Encoding.GetEncoding("utf-8");
                string responseString = encoding.GetString(bytes, 0, bytes.Length);

                return responseString;
            }  
            catch(HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");	
                Console.WriteLine("Message :{0} ",e.Message);
                return "";
            }
        }
    }
}