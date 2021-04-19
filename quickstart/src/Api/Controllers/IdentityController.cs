using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("identity")]
    public class IdentityController : Controller
    {
        public IdentityController()
        {

        }

        [HttpPost]
        public async Task<IActionResult> TokenConnect(ConnectTokenModel data)
        {
            var httpResult = await identityCall(data);

            return Ok(httpResult);
        }

        private async Task<HttpResponseMessage> identityCall(ConnectTokenModel data)
        {
            var client = new HttpClient();
            var res = await client.PostAsJsonAsync("https://localhost:5001/connect/token", data);

            return res;
        }
    }
}
