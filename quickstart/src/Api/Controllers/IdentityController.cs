using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("[controller]")]
    public class IdentityController : Controller
    {
        private string ConnectTokenUrl => "https://localhost:5001/connect/token";
        private string ConnectTokenUrlTest => "https://requestinspector.com/inspect/01f3qegpdmm6mg9ngmqpphxmhh";
        public IdentityController()
        {
            
        }

        [HttpPost]
        public async Task<IActionResult> TokenConnect(ConnectTokenModel data)
        {
            var httpResult = await identityCall(data);
            
            return Ok(httpResult);
        }
        [Route("tokenConnect2")]
        [HttpPost]
        public async Task<IActionResult> TokenConnect2(ConnectTokenModel data)
        {
            var result = Redirect(ConnectTokenUrlTest);

            return result;
        }
        private async Task<HttpResponseMessage> identityCall(ConnectTokenModel data)
        {
            var client = new HttpClient();
            //var res = await client.PostAsJsonAsync(ConnectTokenUrlTest, data);
            
            var res = await client.PostAsync(ConnectTokenUrlTest, new StreamContent(Request.Body));

            return res;
        }
        private async Task identityCall2(ConnectTokenModel data)
        {
            Redirect("");
        }

        private HttpContent composeContent(ConnectTokenModel data) {
            HttpContent result;
            HttpRequestMessage options = new HttpRequestMessage();
            IdentityUser user = new IdentityUser();
            return null;
        }
    }
}
