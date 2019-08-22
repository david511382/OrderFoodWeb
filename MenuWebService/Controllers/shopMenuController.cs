using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MenuWebService.Controllers
{
    [Route("menu/[controller]")]
    [ApiController]
    public class ShopMenuController : ControllerBase
    {
        // GetShopMenu 取得菜單
        // @Tags menu
        // @Summary 取得菜單
        // @Description 取得菜單
        // @Produce  json
        // @Param shopID path string true "商店"
        // @Success 200 {object} resp.ShopMenu "菜單"
        // @Failure 500 {string} string "内部错误"
        // @Router /manager/menu/shopmenu/{shopID} [get]
        // GET menu/shopmenu/5
        [HttpGet("{shopID}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}
