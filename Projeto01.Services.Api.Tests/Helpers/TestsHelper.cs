using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Services.Api.Tests.Helpers
{
    public class TestsHelper
    {
        private static string _accessToken
            => "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiZHVhcnRlMzEwOEBob3RtYWlsLmNvbSIsIm5iZiI6MTY2MTE5NDc3OSwiZXhwIjoxNjYxMjE2Mzc5LCJpYXQiOjE2NjExOTQ3Nzl9.NbZVHO6ohesjnmybEi-LDxbRtB9akKjhoPX6hoK_M2M";

        public static HttpClient CreateClient()
        {
            var applicarion = new WebApplicationFactory<Program>();
           var client  = applicarion.CreateClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
            
            return client;
        }

        public static StringContent CreateContent<TRequest>(TRequest request)
        {
            return new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");
        }
        public static TResponse CreateResponse<TResponse>(HttpResponseMessage message)
        {
            return JsonConvert.DeserializeObject<TResponse>(message.Content.ReadAsStringAsync().Result);
        }
    }
}
