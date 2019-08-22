using Microsoft.AspNetCore.Mvc;

namespace MenuWebService.Controllers
{
    [Route("menu/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        // UpdateOption 修改商品選單
        // @Tags menu
        // @Summary 修改商品選單
        // @Description 修改商品選單
        // @Produce  json
        // @Param selectNum formData int true "商品選單"
        // @Success 200 {string} string "成功"
        // @Failure 500 {string} string "内部错误"
        // @Router /manager/menu/option/{id} [put]
        // PUT menu/option/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DeleteOption 刪除商品選單
        // @Tags menu
        // @Summary 刪除商品選單
        // @Description 刪除商品選單
        // @Produce  json
        // @Param id path int true "ID"
        // @Success 200 {string} result "成功"
        // @Failure 500 {string} string "内部错误"
        // @Router /manager/menu/option/{id} [delete]
        // DELETE menu/option/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
