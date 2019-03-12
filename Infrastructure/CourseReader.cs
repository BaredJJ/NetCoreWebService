using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace WebService.Infrastructure
{
    public class CourseReader
    {
        public async Task<Stream> GetRequest(Uri request)
        {
            var webRequest = WebRequest.Create(request);
            var response = await webRequest.GetResponseAsync();
            return response.GetResponseStream();
        }
    }
}
