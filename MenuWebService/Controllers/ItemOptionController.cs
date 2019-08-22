using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MenuWebService.Controllers
{
    [Route("menu/[controller]")]
    [ApiController]
    public class ItemOptionController : ControllerBase
    {
        // AddItemOption 商品加入選單
        // @Tags menu
        // @Summary 商品加入選單
        // @Description 商品加入選單
        // @Accept  x-www-form-urlencoded
        // @Produce  json
        // @Param itemID formData int true "商品編號"
        // @Param optionID formData int true "選單編號"
        // @Success 200 {object} resp.ItemOption "結果"
        // @Failure 500 {string} string "内部错误"
        // @Router /manager/menu/itemoption [post]
        // POST menu/itemoption
        [HttpPost]
        public async Task Post([FromBody] string name,int shopID,int price)
        {
        }

        // DeleteItemOption 刪除選單的商品
        // @Tags menu
        // @Summary 刪除選單的商品
        // @Description 刪除選單的商品
        // @Produce  json
        // @Param id path int true "ID"
        // @Success 200 {string} result "成功"
        // @Failure 500 {string} string "内部错误"
        // @Router /manager/menu/itemoption/{id} [delete]
        // DELETE menu/itemoption/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
