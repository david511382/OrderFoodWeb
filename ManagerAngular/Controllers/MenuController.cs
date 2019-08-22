using ManagerAngular.Models.Menu;
using ManagerAngular.Util.http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagerAngular.Controllers
{
    [Route("api/[controller]")]
    public class MenuController : Controller
    {
        [HttpGet("[action]")]
        public async Task<IEnumerable<Shop>> GetShops()
        {
            var response = await Http.Get("http://localhost:55138/menu/Shop");
            var result = JsonConvert.DeserializeObject<Shop[]>(response.Content);
            return result;
        }
    }
}
