using MenuLogic.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuWebService.Controllers
{
    [Route("menu/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopLogic _logic;

        public ShopController(IShopLogic service)
        {
            _logic = service;
        }

        // GetShop 取得商店
        // @Tags menu
        // @Summary 取得商店
        // @Description 取得商店
        // @Produce  json
        // @Param id query string false "編號"
        // @Param name query string false "商名"
        // @Success 200 {array} resp.Shop "菜單"
        // @Failure 500 {string} string "内部错误"
        // @Router /manager/menu/shop [get]
        // GET api/shop
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopLogicModel>>> Get([FromQuery] int id, string name)
        {
            IEnumerable<ShopLogicModel> result = await _logic.GetShop(id, name);
            return new ActionResult<IEnumerable<ShopLogicModel>>(result);
        }

        // AddShop 新增商店
        // @Tags menu
        // @Summary 新增商店
        // @Description 新增商店
        // @Accept  x-www-form-urlencoded
        // @Produce  json
        // @Param name formData string true "商名"
        // @Success 200 {object} resp.Shop "菜單"
        // @Failure 500 {string} string "内部错误"
        // @Router /manager/menu/shop [post]
        // POST menu/shop
        [HttpPost]
        public async Task<int> Post([FromForm] string name)
        {
            return await _logic.AddShop(name);
        }

        // UpdateShop 修改商店
        // @Tags menu
        // @Summary 修改商店
        // @Description 修改商店
        // @Accept  x-www-form-urlencoded
        // @Produce  json
        // @Param id path int true "編號"
        // @Param name formData string true "店名"
        // @Success 200 {string} string "結果"
        // @Failure 500 {string} string "内部错误"
        // @Router /manager/menu/shop/{id} [put]
        // PUT menu/shop/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] string name)
        {
            await _logic.UpdateShop(id, name);
        }

        // DeleteShop 刪除商店
        // @Tags menu
        // @Summary 刪除商店
        // @Description 刪除商店
        // @Produce  json
        // @Param id path int true "編號"
        // @Success 200 {string} result "成功"
        // @Failure 500 {string} string "内部错误"
        // @Router /manager/menu/shop/{id} [delete]
        // DELETE menu/shop/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _logic.DeleteShop(id);
        }
    }
}
