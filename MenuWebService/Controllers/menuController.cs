using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MenuWebService.Controllers
{
    [Route("menu/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        // GetMenu 取得菜單
        // @Tags menu
        // @Summary 取得菜單
        // @Description 取得菜單
        // @Produce  json
        // @Param shop path string true "商店"
        // @Success 200 {array} resp.ShopMenu "菜單"
        // @Failure 500 {string} string "内部错误"
        // @Router /manager/menu/menu/{shop} [get]
        // GET menu/menu/5
        [HttpGet("{shopID}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}
