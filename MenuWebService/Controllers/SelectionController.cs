using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MenuWebService.Controllers
{
    [Route("menu/[controller]")]
    [ApiController]
    public class SelectionController : ControllerBase
    {
        // DeleteSelection 刪除選單選項
        // @Tags menu
        // @Summary 刪除選單選項
        // @Description 刪除選單選項
        // @Produce  json
        // @Param id path int true "ID"
        // @Success 200 {string} result "成功"
        // @Failure 500 {string} string "内部错误"
        // @Router /manager/menu/selection/{id} [get]
        // GET menu/selection/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // AddSelection 新增選單選項
        // @Tags menu
        // @Summary 新增選單選項
        // @Description 新增選單選項
        // @Accept  x-www-form-urlencoded
        // @Produce  json
        // @Param optionID formData int true "選單編號"
        // @Param name formData string true "名稱"
        // @Param price formData int false "價格"
        // @Success 200 {object} resp.MenuSelection "菜單"
        // @Failure 500 {string} string "内部错误"
        // @Router /manager/menu/selection [post]
        // POST menu/selection
        [HttpPost]
        public async Task Post([FromBody] string name,int shopID,int price)
        {
        }

        // UpdateSelection 修改選單選項
        // @Tags menu
        // @Summary 修改選單選項
        // @Description 修改選單選項
        // @Produce  json
        // @Param name formData string false "名稱"
        // @Param price formData int false "價格"
        // @Success 200 {string} string "結果"
        // @Failure 500 {string} string "内部错误"
        // @Router /manager/menu/selection/{id} [put]
        // PUT menu/selection/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
