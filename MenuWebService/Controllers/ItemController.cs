using MenuLogic.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuWebService.Controllers
{
    [Route("menu/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemLogic _logic;

        public ItemController(IItemLogic service)
        {
            _logic = service;
        }

        // GetItem 取得商品
        // @Tags menu
        // @Summary 取得商品
        // @Description 取得商品
        // @Produce  json
        // @Param shopID path int true "商店編號"
        // @Param optionID query int false "選單編號"
        // @Success 200 {array} resp.Item "菜單"
        // @Failure 500 {string} string "内部错误"
        // @Router /manager/menu/item/{shopID} [get]
        // GET menu/item/5
        [HttpGet("{shopID}")]
        public async Task<ActionResult<IEnumerable<ItemLogicModel>>> Get(int shopID, [FromQuery] int optionID)
        {
            IEnumerable<ItemLogicModel> result = await _logic.GetItem(shopID, optionID);
            return new ActionResult<IEnumerable<ItemLogicModel>>(result);
        }

        // AddItem 新增商品
        // @Tags menu
        // @Summary 新增商品
        // @Description 新增商品
        // @Accept  x-www-form-urlencoded
        // @Produce  json
        // @Param shopID formData int true "商店"
        // @Param name formData string true "商名"
        // @Param price formData int false "價格"
        // @Success 200 {object} resp.Item "菜單"
        // @Failure 500 {string} string "内部错误"
        // @Router /manager/menu/item [post]
        // POST menu/item
        [HttpPost]
        public async Task<int> Post([FromBody] string name, int shopID, int price)
        {
            return await _logic.AddItem(shopID, name, price);
        }

        // UpdateItem 修改商品
        // @Tags menu
        // @Summary 修改商品
        // @Description 修改商品
        // @Accept  x-www-form-urlencoded
        // @Produce  json
        // @Param id path int true "編號"
        // @Param name formData string false "品名"
        // @Param price formData int false "價格"
        // @Success 200 {string} string "結果"
        // @Failure 500 {string} string "内部错误"
        // @Router /manager/menu/item/{id} [put]
        // PUT menu/item/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] int shopID, string name, int price)
        {
            await _logic.UpdateItem(id, shopID, name, price);
        }

        // DeleteItem 刪除商品
        // @Tags menu
        // @Summary 刪除商品
        // @Description 刪除商品
        // @Produce  json
        // @Param id path int true "編號"
        // @Success 200 {string} result "成功"
        // @Failure 500 {string} string "内部错误"
        // @Router /manager/menu/item/{id} [delete]
        // DELETE menu/item/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _logic.DeleteItem(id);
        }
    }
}
