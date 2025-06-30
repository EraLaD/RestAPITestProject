using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPITestProject.support.utils
{
    public static class URLBuilder       
    {
        private static HttpClient client;

        static URLBuilder()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://api.restful-api.dev/")
            };
            
        }
        public static HttpClient GetHttpClient()
        {
            return client;
        }
    }
}
